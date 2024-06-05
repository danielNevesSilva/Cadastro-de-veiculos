using System;

namespace Cadastro_de_veiculos.Models
{

        public class ErrorViewModel
        {
            public string? RequestId { get; set; }

            public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        }
    }
