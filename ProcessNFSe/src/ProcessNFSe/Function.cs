using Amazon.Lambda.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Tecware.Titanium.Domain.ServicosTomados__Municipios_;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ProcessNFSe
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public void ProcessaServicoTomado(int codigo)
        {
            try
            {
                IFormFile[] xml = HttpContext.Request.Form.Files.ToArray();
                using (var stream = new MemoryStream())
                using (var xmlStream = xml.First().OpenReadStream())
                {
                    xmlStream.CopyTo(stream);
                    XmlDocument xmlDoc = new XmlDocument();
                    stream.Position = 0;
                    xmlDoc.Load(stream);
                    XmlNodeList NFes = xmlDoc.GetElementsByTagName("NOTA_FISCAL");
                    Cidade cidade = await _enderecoRepository.GetCidadeByIBGE(codigo);
                    switch (cidade.IBGE)
                    {
                        case 3552205:
                            List<Modelo01> list = new List<Modelo01>();
                            for (int i = 0; i < NFes.Count; i++)
                            {
                                if (NFes[i].InnerText.Length > 0)
                                {
                                    XmlDocument nfe = new XmlDocument();
                                    nfe.LoadXml(NFes[i].OuterXml);
                                    formatXMLDecimal(nfe);

                                    Modelo01 nota = DeserializeObject<Modelo01>(nfe.OuterXml);

                                    #region Verificando se o CNPJ do tomador ou prestador existem no banco
                                    List<Endereco> enderecos = new List<Endereco>();
                                    List<Telefone> telefones = new List<Telefone>();
                                    var tomador = await _empresasRepository.GetByCNPJAsync(nota.TomadorCPFCNPJ);
                                    var prestador = await _empresasRepository.GetByCNPJAsync(nota.PrestadorCPFCNPJ);
                                    if (tomador == null)
                                    {
                                        enderecos.Add(new Endereco
                                        {
                                            Cep = nota.TomadorCEP,
                                            Logradouro = nota.TomadorTipoLogradouro + nota.TomadorLogradouro,
                                            Numero = nota.TomadorNumero,
                                            Pais = "BRASIL",
                                            Cidade = nota.TomadorCidade,
                                            Estado = nota.TomadorUF,
                                            Bairro = nota.TomadorBairro
                                        });

                                        telefones.Add(new Telefone
                                        {
                                            Numero = "(0" + nota.TomadorDDDTelefone + ")" + nota.TomadorTelefone,
                                            Tipo = TipoTelefone.Comercial,
                                            Padrao = 1
                                        });

                                        tomador = new Empresa
                                        {
                                            CodigoPasta = 301,
                                            Nome = nota.TomadorRazaoSocial,
                                            Razao = nota.TomadorRazaoSocial,
                                            Pessoa = nota.TomadorCPFCNPJ.Length == 14 ? 2 : 1,
                                            Cnpj = nota.TomadorCPFCNPJ,
                                            Usuario = User.GetTitaniumUserId(),
                                            Credito = 0,
                                            Enderecos = enderecos,
                                            Telefones = telefones
                                        };

                                        await _empresasRepository.AddEmpresaAsync(tomador);
                                    }

                                    if (prestador == null)
                                    {
                                        enderecos.Add(new Endereco
                                        {
                                            Cep = nota.PrestadorCEP,
                                            Logradouro = nota.PrestadorTipoLogradouro + nota.PrestadorLogradouro,
                                            Numero = nota.PrestadorPrestNumero,
                                            Complemento = nota.PrestadorComplemento,
                                            Pais = "BRASIL",
                                            Cidade = nota.PrestadorCidade,
                                            Estado = nota.PrestadorUF,
                                            Bairro = nota.PrestadorBairro
                                        });

                                        telefones.Add(new Telefone
                                        {
                                            Numero = "(0" + nota.TomadorDDDTelefone + ")" + nota.TomadorTelefone,
                                            Tipo = TipoTelefone.Comercial,
                                            Padrao = 1
                                        });

                                        prestador = new Empresa
                                        {
                                            CodigoPasta = 301,
                                            Nome = nota.PrestadorNomeFantasia,
                                            Razao = nota.PrestadorRazaoSocial,
                                            Pessoa = nota.PrestadorCPFCNPJ.Length == 14 ? 2 : 1,
                                            Cnpj = nota.PrestadorCPFCNPJ,
                                            Usuario = User.GetTitaniumUserId(),
                                            Credito = 0,
                                            Enderecos = enderecos,
                                            Telefones = telefones,
                                        };

                                        await _empresasRepository.AddEmpresaAsync(prestador);
                                    }
                                    #endregion

                                    #region Verificando se o serviço vindo do XML existe no banco
                                    bool servico = await _servicosRepository.verifyServicoByNumber(nota.COSServico);

                                    if (!servico)
                                    {
                                        Servico servicoModel = new Servico
                                        {
                                            numero = int.Parse(nota.COSServico),
                                            descricao = nota.DescricaoServico,
                                            iss = nota.Aliquota,
                                            cidade = cidade.IBGE,
                                            descricaoAtividade = nota.DescricaoAtividade.ToUpper()
                                        };

                                        await _servicosRepository.postServicoAsync(servicoModel);
                                    }
                                    #endregion

                                    list.Add(nota);
                                }
                            }
                            await _servicosTomadosRepository.PostNotaXML(list);
                            break;
                    }
                    return Ok(new GenericResponse(true, "XML processado com sucesso!"));
                }
            }

            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public static void formatXMLDecimal(XmlDocument nfe)
        {
            XmlNode node;
            for (var c = 0; c < nfe.GetElementsByTagName("ITEM").Count; c++)
            {
                node = nfe.GetElementsByTagName("VALOR_TOTAL")[c];
                node.InnerText = node.InnerText.Replace(",", ".");

                node = nfe.GetElementsByTagName("VALOR_UNITARIO")[c];
                node.InnerText = node.InnerText.Replace(",", ".");

                node = nfe.GetElementsByTagName("VALOR_ISS_UNITARIO")[c];
                node.InnerText = node.InnerText.Replace(",", ".");
            }

            node = nfe.GetElementsByTagName("VALOR_DEDUCAO")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("VALOR_SERVICO")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("VALOR_NOTA")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("VALOR_INSS")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("VALOR_ISS")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("VALOR_PIS")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("VALOR_COFINS")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("VALOR_IR")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("VALOR_CSLL")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("ALIQUOTA_PIS")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("ALIQUOTA_COFINS")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("ALIQUOTA_INSS")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("ALIQUOTA_IR")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("ALIQUOTA_CSLL")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("VALOR_ISS_RET")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("DESCONTO_RET")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("ALIQ_RET")[0];
            node.InnerText = node.InnerText.Replace(",", ".");

            node = nfe.GetElementsByTagName("DEDUCAO_VALOR_ATIVIDADE")[0];
            if (node != null)
                node.InnerText = node.InnerText.Replace(",", ".");
        }
    }
}
