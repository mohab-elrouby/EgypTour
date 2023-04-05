using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;

namespace Domain.Response
{
    public class GenericResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingDefault)]
        public T Data { get; set; } = default(T);
    }
}
