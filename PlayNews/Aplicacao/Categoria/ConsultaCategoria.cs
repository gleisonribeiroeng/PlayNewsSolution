﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayNews.Aplicacao.Categoria
{
    public class ConsultaCategoria : IRequest<List<ConsultaCategoriaResultado>>
    {
    }
}