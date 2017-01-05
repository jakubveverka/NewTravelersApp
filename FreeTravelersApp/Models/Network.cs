using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
namespace FreeTravelersApp.Models
{
	public class Network
	{
		public Network()
		{
		}

		public async Task<Type> FetchResponseAsync<Type>(string url)
		{
			using (var client = new HttpClient())
			{
				try
				{
					var responseText = await client.GetStringAsync(url);
					return JsonConvert.DeserializeObject<Type>(responseText);
				}
				catch (HttpRequestException ex)
				{
					return default(Type);
				}
			}
		}

		public async Task<HttpResponseMessage> PostRequestAsync<T>(string url, T entity, params Expression<Func<T, object>>[] properties)
		{
			var values = new List<KeyValuePair<string, string>>();
			foreach (var property in properties)
			{
				var value = property.Compile().Invoke(entity).ToString();
				var expression = property.Body as MemberExpression;
				values.Add(new KeyValuePair<string, string>(expression.Member.Name, value));
			}
			var content = new FormUrlEncodedContent(values);

			using (var client = new HttpClient())
			{
				try
				{
					return await client.PostAsync(url, content);
				}
				catch (HttpRequestException ex)
				{
					return null;
				}
			}
		}

		#region AsyncCalls
		public void BeforeWait(Layout<View> container)
		{
			container.Children.Clear();
			container.Children.Add(new Label { Text = "Načítám data..." });
			container.Children.Add(new ActivityIndicator { IsRunning = true });
		}
		public void AfterWait(Layout<View> container)
		{
			container.Children.Clear();
		}
		public async Task<TResult> WaitRequest<TResult>(Layout<View> container, Func<Task<TResult>> callMethod)
		{
			BeforeWait(container);
			var result = await callMethod();
			AfterWait(container);
			return result;
		}
		public async Task<TResult> WaitRequest<TResult, Arg1>(StackLayout container, Func<Arg1, Task<TResult>> callMethod, Arg1 arg1)
		{
			BeforeWait(container);
			var result = await callMethod(arg1);
			AfterWait(container);
			return result;
		}
		public async Task<TResult> WaitRequest<TResult, Arg1, Arg2>(StackLayout container, Func<Arg1, Arg2, Task<TResult>> callMethod, Arg1 arg1, Arg2 arg2)
		{
			BeforeWait(container);
			var result = await callMethod(arg1, arg2);
			AfterWait(container);
			return result;
		}
		public async Task<TResult> WaitRequest<TResult, Arg1, Arg2, Arg3>(StackLayout container, Func<Arg1, Arg2, Arg3, Task<TResult>> callMethod, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			BeforeWait(container);
			var result = await callMethod(arg1, arg2, arg3);
			AfterWait(container);
			return result;
		}
		#endregion
	}
}
