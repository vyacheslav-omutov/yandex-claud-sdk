using System.Text.Json.Serialization;

namespace Yandex.ID.Helpers;

public static class UriHelper
{
    public static Dictionary<string, string?> CreateQueryParamsFromRequest<TRequest>(TRequest request)
        where TRequest : class
    {
        var queries = new Dictionary<string, string?>();
        foreach (var property in typeof(TRequest).GetProperties())
        {
            var attributes = property.GetCustomAttributes(typeof(JsonPropertyNameAttribute), true);
            foreach (JsonPropertyNameAttribute propertyNameAttribute in attributes)
            {
                var value = property.GetValue(request);
                if (value is null) continue;
                
                var propertyValue = value.ToString()?.ToLower();
                queries.Add(propertyNameAttribute.Name, propertyValue);
            }
        }

        return queries;
    }
}