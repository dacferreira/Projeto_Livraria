using System;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Projeto_Livraria.Dominio.Entities.Livros;

namespace Projeto_Livraria.Dominio.Excecoes
{
    [Serializable]
    public class ValidacaoException : Exception
    {
        private readonly List<ValidationFailure> _erros;

        public ValidacaoException()
        {
            throw new ArgumentException("Nenhum erro associado");
        }

        public ValidacaoException(string message) : base(message)
        {
            throw new ArgumentException("Nenhum erro associado");
        }

        public ValidacaoException(string message, IEnumerable<ValidationFailure> erros) :
            base(message)
        {
            if (!erros.Any())
                throw new ArgumentException("Nenhum erro associado.");

            _erros = new List<ValidationFailure>();
            _erros.AddRange(erros);
        }

        public ValidacaoException(string message, ValidationFailure erros)
            : base(message)
        {
            if (erros != null)
                throw new ArgumentException("Nenhum erro associado.");

            _erros = new List<ValidationFailure>();
            _erros.Add(erros);
        }

        public ValidacaoException(string message, Exception innerException) : base(message, innerException)
        {
            throw new ArgumentException("Nenhum erro associado.");
        }

        protected ValidacaoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            throw new ArgumentException("Nenhum erro associado.");
        }

        public IEnumerable<Erro> ObterErros()
        {
            var erros = new List<Erro>();
            _erros?.ForEach(falha =>
                erros.Add(new Erro
                {
                    Campo = falha.PropertyName,
                    Mensagem = falha.ErrorMessage
                })
            );

            return erros;
        }

        public override string ToString()
        {
            var erros = new StringBuilder();
            _erros?.ForEach(falha => erros.Append($"{falha.PropertyName}: {falha.ErrorMessage}"));
            return erros.ToString();
        }
    }
}
