using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;

namespace SPROUTEXAM.Configurations
{
    public class FluentValidation
    {
        internal static void AddFluentValidation (IMvcBuilder mvcBuilder) 
        {
            mvcBuilder.AddFluentValidation (fv => 
            {
                fv.RegisterValidatorsFromAssemblyContaining<Application.Exceptions.RecordNotFoundException> ();
                fv.ImplicitlyValidateChildProperties = true;
            });
        }
    }
}