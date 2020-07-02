using OpenQA.Selenium;

namespace Amazonproj.Pages
{
    /// <summary>
    /// Search Page of App
    /// </summary>
    public class SearchPage
    {

        //objects
        #region objects
        public By searchTextboxMini = By.Id("in.amazon.mShop.android.shopping:id/search_edit_text");
        public By searchTextboxFull = By.Id("in.amazon.mShop.android.shopping:id/search_auto_text");
        public string purchaseItem = "android.view.View";
        public string addtoCartButton = "add-to-cart-button";
        public By cartIcon = By.ClassName("android.widget.TextView");
        public string proceedToCheckout = "Proceed to Buy";
        public By searchSuggession = By.ClassName("android.widget.TextView");
        public By searchPopTextPath = By.XPath("//android.widget.TextView");
        public string deliverTothisAddressButton = "a-autoid-0-announce";
        public By continueButton = By.ClassName("android.widget.Button");
        public string listviewOfSearchResults = "resultItems";
        public string containerForSearchItem = "title_feature_div";
        public string cartContainer = "activeCartViewForm";

        #endregion


    }
}
