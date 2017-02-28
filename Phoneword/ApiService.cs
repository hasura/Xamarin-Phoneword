using ModernHttpClient;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace Phoneword
{
	public class ApiService
	{
		HttpClient client = new HttpClient(new NativeMessageHandler());

		public async Task<TranslationReturningResponse> AddTranslation(TranslationRecord record)
		{
			InsertTranslationQuery query = new InsertTranslationQuery(record);
			var data = JsonConvert.SerializeObject(query);
			var content = new StringContent(data, Encoding.UTF8, "application/json");
			Debug.WriteLine("Content");
			Debug.WriteLine(data);
			var response = await client.PostAsync(Endpoint.QUERY_URL, content);
			Debug.WriteLine(response);
			var result = JsonConvert.DeserializeObject<TranslationReturningResponse>(response.Content.ReadAsStringAsync().Result);
			return result;
		}

		public async Task<List<TranslationRecord>> GetTranslations()
		{
			SelectTranslationQuery query = new SelectTranslationQuery();
			var data = JsonConvert.SerializeObject(query);
			var content = new StringContent(data, Encoding.UTF8, "application/json");
			Debug.WriteLine("Content");
			Debug.WriteLine(data);
			var response = await client.PostAsync(Endpoint.QUERY_URL, content);
			Debug.WriteLine(response);
			var result = JsonConvert.DeserializeObject<List<TranslationRecord>>(response.Content.ReadAsStringAsync().Result);
			return result;
		}
	}
}
