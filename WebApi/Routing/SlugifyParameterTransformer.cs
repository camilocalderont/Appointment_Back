namespace Appointment_Back.Routing;
using Microsoft.AspNetCore.Routing;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object value)
    {
        if (value == null) { return null; }

        // Convertir a minúsculas
        return value.ToString().ToLowerInvariant();
    }
}