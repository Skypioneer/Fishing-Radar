using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

using Moq;

using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models;

namespace UnitTests
{
    /// <summary>
    /// Helper to hold the web start settings
    ///
    /// HttpClient
    /// 
    /// Action Contect
    /// 
    /// The View Data and Teamp Data
    /// 
    /// The Product Service
    /// </summary>
    public static class PageTestsHelper
    {
        public static Mock<IWebHostEnvironment> MockWebHostEnvironment;
        public static IUrlHelperFactory UrlHelperFactory;
        public static DefaultHttpContext HttpContextDefault;
        public static IWebHostEnvironment WebHostEnvironment;
        public static ModelStateDictionary ModelState;
        public static ActionContext ActionContext;
        public static EmptyModelMetadataProvider ModelMetadataProvider;
        public static ViewDataDictionary ViewData;
        public static TempDataDictionary TempData;
        public static PageContext PageContext;
        public static JsonFileProductService<PostModel> ProductService;
        public static JsonFileProductService<FishingSpotModel> FishingSpotService;
        public static JsonFileProductService<FishingGuideModel> FishingGuideService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        static PageTestsHelper()
        {
            MockWebHostEnvironment = new Mock<IWebHostEnvironment>();
            MockWebHostEnvironment.Setup(m => m.EnvironmentName).Returns("Hosting:UnitTestEnvironment");
            MockWebHostEnvironment.Setup(m => m.WebRootPath).Returns(TestFixture.DataWebRootPath);
            MockWebHostEnvironment.Setup(m => m.ContentRootPath).Returns(TestFixture.DataContentRootPath);

            HttpContextDefault = new DefaultHttpContext()
            {
                TraceIdentifier = "trace",
            };
            HttpContextDefault.HttpContext.TraceIdentifier = "trace";

            ModelState = new ModelStateDictionary();

            ActionContext = new ActionContext(HttpContextDefault, HttpContextDefault.GetRouteData(), new PageActionDescriptor(), ModelState);

            ModelMetadataProvider = new EmptyModelMetadataProvider();
            ViewData = new ViewDataDictionary(ModelMetadataProvider, ModelState);
            TempData = new TempDataDictionary(HttpContextDefault, Mock.Of<ITempDataProvider>());

            PageContext = new PageContext(ActionContext)
            {
                ViewData = ViewData,
                HttpContext = HttpContextDefault
            };

            ProductService = new JsonFileProductService<PostModel>(MockWebHostEnvironment.Object);

            JsonFileProductService<PostModel> productService;

            productService = new JsonFileProductService<PostModel>(PageTestsHelper.MockWebHostEnvironment.Object);

            FishingSpotService = new JsonFileProductService<FishingSpotModel>(MockWebHostEnvironment.Object);

            JsonFileProductService<FishingSpotModel> fishingSpotService;

            fishingSpotService = new JsonFileProductService<FishingSpotModel>(PageTestsHelper.MockWebHostEnvironment.Object);

            FishingGuideService = new JsonFileProductService<FishingGuideModel>(MockWebHostEnvironment.Object);

            JsonFileProductService<FishingGuideModel> fishingGuideService;

            fishingGuideService = new JsonFileProductService<FishingGuideModel>(PageTestsHelper.MockWebHostEnvironment.Object);
        }
    }
}