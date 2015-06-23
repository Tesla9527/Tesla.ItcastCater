using Tesla.ItcastCater.UIMap.LoginPageUIClasses;
using Tesla.ItcastCater.UIMap.ProductPageUIClasses;

namespace Tesla.ItcastCater.Modules
{
    #region ItcastCater Roadmap
    /// <summary>
    /// Overall roadmap of ItcastCater application, aiming at including all modules eventually
    /// </summary>
    public class ItcastCaterModules
    {
        private static LoginPageUI loginPageUI;
        private static ProductPageUI productPageUI;

        /// <summary>
        /// New instance of class LoginPageUI if null
        /// </summary>
        public static LoginPageUI LoginPageUI
        {
            get
            {
                if (loginPageUI == null)
                {
                    return new LoginPageUI();
                }
                return loginPageUI;
            }
            set { ItcastCaterModules.loginPageUI = value; }
        }

        /// <summary>
        /// New instance of class ProductPageUI if null
        /// </summary>
        public static ProductPageUI ProductPageUI
        {
            get
            {
                if (productPageUI == null)
                {
                    return new ProductPageUI();
                }
                return productPageUI;
            }
            set { ItcastCaterModules.productPageUI = value; }
        }
    }
    #endregion
}
