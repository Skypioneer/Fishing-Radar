using Bunit;
using NUnit.Framework;

using ContosoCrafts.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;
/// <summary>
/// Bunit tests for components on ProductList razor page
/// </summary>
namespace UnitTests.Components
{
    /// <summary>
    /// Bunit test class for ProductLists unit tests
    /// </summary>
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(PageTestsHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Lake Trout from Green Lake"));
        }

        #region SelectProduct
        [Test]
        public void SelectProduct_Valid_ID_Lake_Trout_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(PageTestsHelper.ProductService);
            var id = "MoreInfoButton_Lake Trout";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Best Lake to fish for lake trout around Seattle area. The best way is still fishing with power bait."));
        }
        #endregion SelectProduct

        #region SubmitRating

        [Test]
        public void SubmitRating_Valid_ID_Click_Unstared_Should_Increment_Count_And_Check_Star()
        {
            /*
             This test tests that the SubmitRating will change the vote as well as the Star checked
             Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed
            The test needs to open the page
            Then open the popup on the card
            Then record the state of the count and star check status
            Then check a star
            Then check again the state of the cound and star check status
            */

            // Arrange
            Services.AddSingleton<JsonFileProductService>(PageTestsHelper.ProductService);
            var id = "MoreInfoButton_Shark";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the First star item from the list, it should not be checked
            var starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }

        [Test]
        public void SubmitRating_Valid_ID_Click_Stared_Should_Increment_Count_And_Leave_Star_Check_Remaining()
        {
            /*
             This test tests that the SubmitRating will change the vote as well as the Star checked
             Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed
            The test needs to open the page
            Then open the popup on the card
            Then record the state of the count and star check status
            Then check a star
            Then check again the state of the cound and star check status
            */

            // Arrange
            Services.AddSingleton<JsonFileProductService>(PageTestsHelper.ProductService);
            var id = "MoreInfoButton_Lake Trout";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the Last star item from the list, it should one that is checked
            var starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("6 Votes"));
            Assert.AreEqual(true, postVoteCountString.Contains("7 Votes"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }
        #endregion SubmitRating


        #region UpdateCommentText
        [Test]

        /// Unit test will take a card and add a new comment by searching the page for its
        /// buttons and then clicking them. It then creates a test comment that should be able
        /// to be seen by the unit test.
        public void UpdateCommentText_New_Comment_Should_Return_Content()
        {

            // Arrange
            Services.AddSingleton<JsonFileProductService>(PageTestsHelper.ProductService);
            var id = "CommentButton_Lake Trout";

            // id of comment button
            var addCommentId = "AddComment";

            // id of save button
            var saveCommentId = "SaveComment";

            // id of text box
            var newCommentId = "NewComment";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // buttons on the card
            var btnList = page.FindAll("Button");
            // Find the one that matches the ID looking for and click it
            var commentButton = btnList.First(m => m.OuterHtml.Contains(addCommentId));
            commentButton.Click();

            // find the save button
            btnList = page.FindAll("Button");
            var saveBtn = btnList.First(m => m.OuterHtml.Contains(saveCommentId));


            // find the text form
            var textEntry = page.FindAll("input");
            var textBox = textEntry.First(m => m.OuterHtml.Contains(newCommentId));
            textBox.Change("Test Comment");

            // act save the comment
            saveBtn.Click();

            var pageMarkup = page.Markup;

            Assert.AreEqual(true, pageMarkup.Contains("Test Comment"));
        }

        #endregion

        #region Filter
        [Test]
        ///
        /// Unit test to check that we can successfully filter our cards by product ids.
        /// Unit test should return just a single card called shark and it tries to search
        /// for another card but can find it because it doesn't reference shark,
        ///
        public void Filter_Search_for_Shark_Should_Return_Content()
        {
            //Arrange
            Services.AddSingleton<JsonFileProductService>(PageTestsHelper.ProductService);
            
            // Card Id
            var id = "Shark";

            // Search Bar Id
            var searchId = "SearchBar";

            // Filter Button
            var filterId = "FilterButton";

            var page = RenderComponent<ProductList>();

            // find the text form
            var textEntry = page.FindAll("input");
            var textBox = textEntry.First(m => m.OuterHtml.Contains(searchId));
            textBox.Change(id);

            // find the buttons
            var btnList = page.FindAll("a");
            var filterBtn = btnList.First(m => m.OuterHtml.Contains(filterId));
            // Act
            filterBtn.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            Assert.AreEqual(true, pageMarkup.Contains("Shark"));
            Assert.AreEqual(false, pageMarkup.Contains("Trout"));

        }

        #endregion

    }
}