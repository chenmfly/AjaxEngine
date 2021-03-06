﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using AjaxEngine.Extends;

namespace AjaxEngine.AjaxHandlers
{
    public class Client
    {
        public WebClient WebClient { get; set; }
        public Client()
        {
            this.WebClient = new WebClient();
            this.WebClient.Encoding = System.Text.Encoding.UTF8;
            this.WebClient.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
        }
        public T Get<T>(string uri, Dictionary<string, object> data)
        {
            this.WebClient.QueryString.Clear();
            if (data != null)
            {
                foreach (var key in data.Keys)
                {
                    string val = (data[key] is string) ? (string)data[key] : Gloabl.Serializer.Serialize(data[key]);
                    this.WebClient.QueryString.Add(key, val);
                }
            }
            var rs = this.WebClient.DownloadString(uri);
            return Gloabl.Serializer.Deserialize<T>(rs);
        }
        public T Get<T>(string uri, object data)
        {
            this.WebClient.QueryString.Clear();
            if (data != null)
            {
                foreach (var key in data.GetProperties())
                {
                    var propVal = data.GetPropertyValue(key.Name);
                    string val = (propVal is string) ? (string)propVal : Gloabl.Serializer.Serialize(propVal);
                    this.WebClient.QueryString.Add(key.Name, val);
                }
            }
            var rs = this.WebClient.DownloadString(uri);
            return Gloabl.Serializer.Deserialize<T>(rs);
        }
        public T Get<T>(string uri)
        {
            return this.Get<T>(uri, null);
        }
        public T Post<T>(string uri, Dictionary<string, object> data)
        {
            this.WebClient.QueryString.Clear();
            if (data != null)
            {
                foreach (var key in data.Keys)
                {
                    string val = (data[key] is string) ? (string)data[key] : Gloabl.Serializer.Serialize(data[key]);
                    this.WebClient.QueryString.Add(key, val);
                }
            }
            var rs = this.WebClient.UploadString(uri, "");
            return Gloabl.Serializer.Deserialize<T>(rs);
        }
        public T Post<T>(string uri)
        {
            return this.Post<T>(uri, null);
        }
        public T Post<T>(string uri, object data)
        {
            this.WebClient.QueryString.Clear();
            if (data != null)
            {
                foreach (var key in data.GetProperties())
                {
                    var propVal = data.GetPropertyValue(key.Name);
                    string val = (propVal is string) ? (string)propVal : Gloabl.Serializer.Serialize(propVal);
                    this.WebClient.QueryString.Add(key.Name, val);
                }
            }
            var rs = this.WebClient.UploadString(uri, "");
            return Gloabl.Serializer.Deserialize<T>(rs);
        }
    }
}
