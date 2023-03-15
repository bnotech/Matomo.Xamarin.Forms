using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Matomo.Xamarin.Forms
{
	public class SimpleStorage
	{
		private static object _syncRoot = new object();
		private static SimpleStorage _instance;

		public static SimpleStorage Instance
		{
			get
			{
				lock (_syncRoot)
					if (_instance == null)
						_instance = new SimpleStorage();
				return _instance;
			}
		}

		private string _filename;
		private Dictionary<string, object> _data;

		private SimpleStorage()
		{
			_filename = "matomodata";
			_data = new Dictionary<string, object>();
			ReadFromDisk();
		}

		public bool HasKey(string key)
		{
			return _data.ContainsKey(key);
		}

		public string Get(string key)
		{
			return Get<string>(key);
		}

		public T Get<T>(string key)
		{
			if (!_data.Any())
				ReadFromDisk();

			return (T)_data[key];
		}

		public T Get<T>(string key, T defaultValue)
		{
			if (HasKey(key))
				return Get<T>(key);

			Put<T>(key, defaultValue);
			return defaultValue;
		}

		public void Put<T>(string key, T value)
		{
			if (HasKey(key))
				_data[key] = value;
			else
				_data.Add(key, value);
			WriteToDisk();
		}

		private void ReadFromDisk()
		{
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) ?? "";
			var filepath = Path.Combine(path, $"{_filename}.json");

            if (File.Exists(filepath))
			{
				using (TextReader file = File.OpenText(filepath))
				{
					var json = file.ReadToEnd();
					_data = (Dictionary<string, object>)JsonConvert.DeserializeObject(json);
				}
			}
		}

		private void WriteToDisk()
		{
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) ?? "";
            var filepath = Path.Combine(path, $"{_filename}.json");

            using (StreamWriter file = File.CreateText(filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, _data);
            }
        }
	}
}

