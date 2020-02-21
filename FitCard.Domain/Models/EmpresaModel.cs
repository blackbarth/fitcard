using System;

namespace FitCard.Domain.Models
{
    public class EmpresaModel
    {
        private Guid _Id;

        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _empresaRazao;

        public string EmpresaRazao
        {
            get { return _empresaRazao; }
            set { _empresaRazao = value; }
        }

        private string _empresaNomeFantasia;

        public string EmpresaNomeFantasia
        {
            get { return _empresaNomeFantasia; }
            set { _empresaNomeFantasia = value; }
        }

        private string _empresaCnpj;

        public string EmpresaCNPJ
        {
            get { return _empresaCnpj; }
            set { _empresaCnpj = value; }
        }

        private string _empresaEmail;

        public string EmpresaEmail
        {
            get { return _empresaEmail; }
            set { _empresaEmail = value; }
        }

        private string _empresaEndereco;

        public string EmpresaEndereco
        {
            get { return _empresaEndereco; }
            set { _empresaEndereco = value; }
        }

        private string _empresaCidade;

        public string EmpresaCidade
        {
            get { return _empresaCidade; }
            set { _empresaCidade = value; }
        }

        private string _empresaEstado;

        public string EmpresaEstado
        {
            get { return _empresaEstado; }
            set { _empresaEstado = value; }
        }

        private string _empresaTelefone;

        public string EmpresaTelefone
        {
            get { return _empresaTelefone; }
            set { _empresaTelefone = value; }
        }
        private string _empresaEstatus;

        public string EmpresaStatus
        {
            get { return _empresaEstatus; }
            set { _empresaEstatus = value; }
        }

        private string _empresaAgencia;

        public string EmpresaAgencia
        {
            get { return _empresaAgencia; }
            set { _empresaAgencia = value; }
        }

        private string _empresaConta;

        public string EmpresaConta
        {
            get { return _empresaConta; }
            set { _empresaConta = value; }
        }

        private CategoriaModel _categoria;

        public CategoriaModel Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        private DateTime _createAt;
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }

        private DateTime _updateAt;
        public DateTime UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }
    }
}