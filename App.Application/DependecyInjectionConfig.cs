using App.Application.Services;
using App.Domain.Interfaces.Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application
{
    public class DependecyInjectionConfig
    {
        public static void Inject(IServiceCollection service)
        {
            service.AddTransient<IPessoaService, PessoaService>();
            service.AddTransient<ICidadeService, CidadeService>();
        }
    }
}
