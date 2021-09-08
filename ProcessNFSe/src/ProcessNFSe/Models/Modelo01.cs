using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Tecware.Titanium.Domain.ServicosTomados__Municipios_
{
    //classe criada como modelo do XML de Serviços Tomados da prefeitura de Sorocaba.
    [XmlRootAttribute(ElementName = "NOTA_FISCAL")]
    public class Modelo01
    {
        public int Codigo { get; set; }

        [XmlElement(ElementName = "TIPO")]
        public string Tipo { get; set; }

        [XmlElement(ElementName = "NUM_NOTA")]
        public int NumNota { get; set; }

        [XmlElement(ElementName = "DATA_HORA_EMISSAO")]
        public string DataHoraEmissao { get; set; }

        [XmlElement(ElementName = "DIA_EMISSAO")]
        public int DiaEmissao { get; set; }

        [XmlElement(ElementName = "MES_COMPETENCIA")]
        public string MesCompetencia { get; set; }

        [XmlElement(ElementName = "SITUACAO_NF")]
        public string SituacaoNF { get; set; }

        [XmlElement(ElementName = "CODIGO_CIDADE")]
        public int CodigoCidade { get; set; }

        [XmlElement(ElementName = "USUARIO_CPF_CNPJ")]
        public string UsuarioCPFCNPJ { get; set; }

        [XmlElement(ElementName = "USUARIO_RAZAO_SOCIAL")]
        public string UsuarioRazaoSocial { get; set; }

        [XmlElement(ElementName = "DATA_HORA_CANCELAMENTO")]
        public string DataHoraCancelamento { get; set; }

        [XmlElement(ElementName = "RPS_EMISSAO")]
        public string RpsEmissao { get; set; }

        [XmlElement(ElementName = "SUB_EMISSAO")]
        public string SubEmissao { get; set; }

        [XmlElement(ElementName = "PRESTADOR_CPF_CNPJ")]
        public string PrestadorCPFCNPJ { get; set; }

        [XmlElement(ElementName = "PRESTADOR_INSCRICAO_MUNICIPAL")]
        public int PrestadorInscricaoMunicipal { get; set; }

        [XmlElement(ElementName = "PRESTADOR_RAZAO_SOCIAL")]
        public string PrestadorRazaoSocial { get; set; }

        [XmlElement(ElementName = "PRESTADOR_NOME_FANTASIA")]
        public string PrestadorNomeFantasia { get; set; }

        [XmlElement(ElementName = "PRESTADOR_TIPO_LOGRADOURO")]
        public string PrestadorTipoLogradouro { get; set; }

        [XmlElement(ElementName = "PRESTADOR_LOGRADOURO")]
        public string PrestadorLogradouro { get; set; }

        [XmlElement(ElementName = "PRESTADOR_PREST_NUMERO")]
        public string PrestadorPrestNumero { get; set; }

        [XmlElement(ElementName = "PRESTADOR_COMPLEMENTO")]
        public string PrestadorComplemento { get; set; }

        [XmlElement(ElementName = "PRESTADOR_TIPO_BAIRRO")]
        public string PrestadorTipoBairro { get; set; }

        [XmlElement(ElementName = "PRESTADOR_BAIRRO")]
        public string PrestadorBairro { get; set; }

        [XmlElement(ElementName = "PRESTADOR_CIDADE_CODIGO")]
        public int PrestadorCidadeCodigo { get; set; }

        [XmlElement(ElementName = "PRESTADOR_CIDADE")]
        public string PrestadorCidade { get; set; }

        [XmlElement(ElementName = "PRESTADOR_UF")]
        public string PrestadorUF { get; set; }

        [XmlElement(ElementName = "PRESTADOR_CEP")]
        public string PrestadorCEP { get; set; }

        [XmlElement(ElementName = "PRESTADOR_DDD_TELEFONE")]
        public int PrestadorDDDTelefone { get; set; }

        [XmlElement(ElementName = "PRESTADOR_TELEFONE")]
        public string PrestadorTelefone { get; set; }

        [XmlElement(ElementName = "TOMADOR_CPF_CNPJ")]
        public string TomadorCPFCNPJ { get; set; }

        [XmlElement(ElementName = "TOMADOR_RAZAO_SOCIAL")]
        public string TomadorRazaoSocial { get; set; }

        [XmlElement(ElementName = "TOMADOR_TIPO_LOGRADOURO")]
        public string TomadorTipoLogradouro { get; set; }

        [XmlElement(ElementName = "TOMADOR_LOGRADOURO")]
        public string TomadorLogradouro { get; set; }

        [XmlElement(ElementName = "TOMADOR_NUMERO")]
        public string TomadorNumero { get; set; }

        [XmlElement(ElementName = "TOMADOR_TIPO_BAIRRO")]
        public string TomadorTipoBairro { get; set; }

        [XmlElement(ElementName = "TOMADOR_BAIRRO")]
        public string TomadorBairro { get; set; }

        [XmlElement(ElementName = "TOMADOR_CIDADE_CODIGO")]
        public int TomadorCidadeCodigo { get; set; }

        [XmlElement(ElementName = "TOMADOR_CIDADE")]
        public string TomadorCidade { get; set; }

        [XmlElement(ElementName = "TOMADOR_UF")]
        public string TomadorUF { get; set; }

        [XmlElement(ElementName = "TOMADOR_CEP")]
        public string TomadorCEP { get; set; }

        [XmlElement(ElementName = "TOMADOR_EMAIL")]
        public string TomadorEmail { get; set; }

        [XmlElement(ElementName = "TOMADOR_OPTANTE_SIMPLES")]
        public string TomadorOptanteSimples { get; set; }

        [XmlElement(ElementName = "TOMADOR_DDD_TELEFONE")]
        public int TomadorDDDTelefone { get; set; }

        [XmlElement(ElementName = "TOMADOR_TELEFONE")]
        public int TomadorTelefone { get; set; }

        [XmlElement(ElementName = "VALOR_NOTA")]
        public decimal ValorNota { get; set; }

        [XmlElement(ElementName = "VALOR_DEDUCAO")]
        public decimal ValorDeducao { get; set; }

        [XmlElement(ElementName = "VALOR_SERVICO")]
        public decimal ValorServico { get; set; }

        [XmlElement(ElementName = "VALOR_ISS")]
        public decimal ValorISS { get; set; }

        [XmlElement(ElementName = "VALOR_PIS")]
        public decimal ValorPIS { get; set; }

        [XmlElement(ElementName = "VALOR_COFINS")]
        public decimal ValorCOFINS { get; set; }

        [XmlElement(ElementName = "VALOR_INSS")]
        public decimal ValorINSS { get; set; }

        [XmlElement(ElementName = "VALOR_IR")]
        public decimal ValorIR { get; set; }

        [XmlElement(ElementName = "VALOR_CSLL")]
        public decimal ValorCSLL { get; set; }

        [XmlElement(ElementName = "ALIQUOTA_PIS")]
        public decimal AliquotaPIS { get; set; }

        [XmlElement(ElementName = "ALIQUOTA_COFINS")]
        public decimal AliquotaCOFINS { get; set; }

        [XmlElement(ElementName = "ALIQUOTA_INSS")]
        public decimal AliquotaINSS { get; set; }

        [XmlElement(ElementName = "ALIQUOTA_IR")]
        public decimal AliquotaIR { get; set; }

        [XmlElement(ElementName = "ALIQUOTA_CSLL")]
        public decimal AliquotaCSLL { get; set; }

        [XmlElement(ElementName = "CODIGO_ATIVIDADE")]
        public int CodigoAtividade { get; set; }

        [XmlElement(ElementName = "DESCRICAO_ATIVIDADE")]
        public string DescricaoAtividade { get; set; }

        [XmlElement(ElementName = "GRUPO_ATIVIDADE")]
        public string GrupoAtividade { get; set; }

        [XmlElement(ElementName = "ENQUADRAMENTO_ATIVIDADE")]
        public string EnquadramentoAtividade { get; set; }

        [XmlElement(ElementName = "LOCAL_INCIDENCIA_ATIVIDADE")]
        public string LocalIncidenciaAtividade { get; set; }

        [XmlElement(ElementName = "TRIBUTAVEL_ATIVIDADE")]
        public string TributavelAtividade { get; set; }

        [XmlElement(ElementName = "DEDUCAO_VALOR_ATIVIDADE")]
        public string DeducaoValorAtividade { get; set; }

        [XmlElement(ElementName = "DEDUCAO_ATIVIDADE")]
        public int DeducaoAtividade { get; set; }

        [XmlElement(ElementName = "ATV_ECON_ATV")]
        public string ATVEconATV { get; set; }

        [XmlElement(ElementName = "COS_SERVICO")]
        public string COSServico { get; set; }

        [XmlElement(ElementName = "DESCRICAO_SERVICO")]
        public string DescricaoServico { get; set; }

        [XmlElement(ElementName = "ALIQUOTA")]
        public decimal Aliquota { get; set; }

        [XmlElement(ElementName = "TIPO_RECOLHIMENTO")]
        public string TipoRecolhimento { get; set; }

        [XmlElement(ElementName = "OPERACAO_TRIBUTACAO")]
        public string OperacaoTributacao { get; set; }

        [XmlElement(ElementName = "CODIGO_REGIME")]
        public int CodigoRegime { get; set; }

        [XmlElement(ElementName = "CIDADE_CODIGO_PRESTACAO")]
        public int CidadeCodigoPrestacao { get; set; }

        [XmlElement(ElementName = "CIDADE_PRESTACAO")]
        public string CidadePrestacao { get; set; }

        [XmlElement(ElementName = "UF_PRESTACAO")]
        public string UFPrestacao { get; set; }

        [XmlElement(ElementName = "DOCUMENTO_PRESTACAO")]
        public string DocumentoPrestacao { get; set; }

        [XmlElement(ElementName = "SERIE_PRESTACAO")]
        public int SeriePrestacao { get; set; }

        [XmlElement(ElementName = "TRIBUTACAO_PRESTACAO")]
        public string TributacaoPrestacao { get; set; }

        [XmlElement(ElementName = "CODIGO_VERIFICACAO")]
        public string CodigoVerificado { get; set; }

        [XmlElement(ElementName = "ID_NOTA_FISCAL")]
        public int IdNotaFiscal { get; set; }

        [XmlElement(ElementName = "VALOR_ISS_RET")]
        public decimal ValorISSRet { get; set; }

        [XmlElement(ElementName = "ALIQ_RET")]
        public string AliqRet { get; set; }

        [XmlElement(ElementName = "DESCONTO_RET")]
        public string DescontoRet { get; set; }

        [XmlElement(ElementName = "ITENS")]
        public Itens Item { get; set; }

        [XmlElement(ElementName = "DEDUCOES")]
        public string Deducoes { get; set; }

        [XmlElement(ElementName = "DESCRICAO_NOTA")]
        public string DescricaoNota { get; set; }

        [XmlElement(ElementName = "PRESTADOR_DDD_FAX")]
        public string PrestadorDDDFax { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEmissao { get; set; }
    }

    public class Itens
    {

        [XmlElement(ElementName = "ITEM")]
        public List<Item> itens { get; set; }
    }

    [XmlRoot(ElementName = "ITEM")]
    public class Item
    {
        [XmlElement(ElementName = "TRIBUTAVEL")]
        public string Tributavel { get; set; }

        [XmlElement(ElementName = "DESCRICAO")]
        public string Descricao { get; set; }

        [XmlElement(ElementName = "QUANTIDADE")]
        public int Quantidade { get; set; }

        [XmlElement(ElementName = "VALOR_UNITARIO")]
        public decimal ValorUnitario { get; set; }

        [XmlElement(ElementName = "VALOR_TOTAL")]
        public decimal ValorTotal { get; set; }

        [XmlElement(ElementName = "DEDUCAO")]
        public string Deducao { get; set; }

        [XmlElement(ElementName = "VALOR_ISS_UNITARIO")]
        public decimal ValorISSUnitario { get; set; }

        public decimal Aliquota { get; set; }
        public decimal ValorISS { get; set; }
    }
}
