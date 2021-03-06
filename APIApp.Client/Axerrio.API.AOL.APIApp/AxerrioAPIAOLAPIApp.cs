// Code generated by Microsoft (R) AutoRest Code Generator 0.9.6.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using System.Net.Http;
using APIApp.Client;
using Microsoft.Rest;

namespace APIApp.Client
{
    public partial class AxerrioAPIAOLAPIApp : ServiceClient<AxerrioAPIAOLAPIApp>, IAxerrioAPIAOLAPIApp
    {
        private Uri _baseUri;
        
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri
        {
            get { return this._baseUri; }
            set { this._baseUri = value; }
        }
        
        private ServiceClientCredentials _credentials;
        
        /// <summary>
        /// Credentials for authenticating with the service.
        /// </summary>
        public ServiceClientCredentials Credentials
        {
            get { return this._credentials; }
            set { this._credentials = value; }
        }
        
        private IArticle _article;
        
        public virtual IArticle Article
        {
            get { return this._article; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Axerrio.API.AOL.APIApp class.
        /// </summary>
        public AxerrioAPIAOLAPIApp()
            : base()
        {
            this._article = new Article(this);
            this._baseUri = new Uri("https://microsoft-apiapp687ab3ddcf064a89af6f2e120e561e9f.azurewebsites.net");
        }
        
        /// <summary>
        /// Initializes a new instance of the Axerrio.API.AOL.APIApp class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public AxerrioAPIAOLAPIApp(params DelegatingHandler[] handlers)
            : base(handlers)
        {
            this._article = new Article(this);
            this._baseUri = new Uri("https://microsoft-apiapp687ab3ddcf064a89af6f2e120e561e9f.azurewebsites.net");
        }
        
        /// <summary>
        /// Initializes a new instance of the Axerrio.API.AOL.APIApp class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public AxerrioAPIAOLAPIApp(HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
            : base(rootHandler, handlers)
        {
            this._article = new Article(this);
            this._baseUri = new Uri("https://microsoft-apiapp687ab3ddcf064a89af6f2e120e561e9f.azurewebsites.net");
        }
        
        /// <summary>
        /// Initializes a new instance of the Axerrio.API.AOL.APIApp class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public AxerrioAPIAOLAPIApp(Uri baseUri, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this._baseUri = baseUri;
        }
        
        /// <summary>
        /// Initializes a new instance of the Axerrio.API.AOL.APIApp class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Credentials for authenticating with the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public AxerrioAPIAOLAPIApp(ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._credentials = credentials;
            
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the Axerrio.API.AOL.APIApp class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Credentials for authenticating with the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public AxerrioAPIAOLAPIApp(Uri baseUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._baseUri = baseUri;
            this._credentials = credentials;
            
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }
    }
}
