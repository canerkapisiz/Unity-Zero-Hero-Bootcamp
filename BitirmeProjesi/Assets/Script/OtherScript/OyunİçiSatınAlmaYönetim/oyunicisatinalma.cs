using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class oyunicisatinalma : MonoBehaviour, IStoreListener
{

    private static IStoreController m_StoreController;          // Unity'nin satın alma sistemini tanımlıyoruz
    private static IExtensionProvider m_StoreExtensionProvider; // Alt satın alma işlevini tanımlıyoruz.

    public static string mekik = "mekik";


    void Start()
    {
        // Eğer Store Verilerimiz boş ise oluşturuyoruz
        if (m_StoreController == null)
        {
            // ürünlerimizi ürün katalogumuza ekliyoruz.
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        // Bağlantı kurdukmu onu kontrol ediyoruz
        if (IsInitialized())
        {
            return;
        }

        // Mağazıma ürün eklemen önce ne yapmamız lazım ? Mağaza açmamız gerekiyor değil mi ?
        // İşte bunu yapmak için builder kullnarak bir mağaza oluşturuyoruz.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Burada oluşturuduğumuz mağazamıza ürünler oluşturuyoruz. Ürünlerin 3 Çeşiti vardır.

        // Consumable =Kullanıcılar Ürünü tekrar tekrar satın alabilirler. 
        /* *Sanal para birimleri
         *Sağlık iksirleri
         * Geçici güç - up.
        */

        // Non - Consumable  =Kullanıcılar Ürünü yalnızca bir kez satın alabilir.
        /*
          * Silah veya zırh
          * Ekstra içeriğe erişim
        */

        // Subscription  =Kullanıcılar, Ürüne sınırlı bir süre için erişebilirler.
        /*Bir online oyuna aylık erişim
        *Günlük bonuslar
        *Ücretsiz deneme
        */


        //      builder.AddProduct(Urununyukaridabelirlediğimadi, ProductType.Consumable);
        // ürünün türü

        // Tüm ürünlerimizi belirledikten sonra artık mağazanın tamamen ürünler ile birlikte oluşturulmasını
        // sağlıyoruz.
        builder.AddProduct(mekik, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        // Yukarıda  tanımladığımız tanımlamarı kontrol ediyor. satın alma sistemi ile sorun varmı yok mu kontrol
        //ediyor. Duruma göre bize cevap döndürüyor.
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    // Örnek ürün alma fonksiyonu, oyunumuzdaki butona tıklanıldığında bu fonksiyon çalışacak
    // bu fonksiyon ürün adını yani tanımlamasını satın alma fonksiyonuna taşıyacaktır.

    public void urunalmafonksiyonnu()
    {

        BuyProductID(mekik);
    }




    // Butonlara tıklanıldığında tetiklenen satın alma fonksiyonudur.
    void BuyProductID(string productId)
    {
        // Bağlantıda sorun varmı yok mu diye kontrol ediyoruz.
        if (IsInitialized())
        {

            // burada dikkat etmen gereken konu, bu fonksiyon string türünde veri alıyorya
            // işte biz onu burada controllerimiza aktarıyoruz ve sistem o id'ye göre
            // ilgili ürünü çekebiliyor.
            Product product = m_StoreController.products.WithID(productId);

            // eğer ürün varsa ve ürün satın alınabilir bir durumdaysa
            if (product != null && product.availableToPurchase)
            {

                // ürünün id değerini lazım olursa böyle alabilirsin.
                // product.definition.id

                // satın alınma için hareketi başlatıyoruz ve InitiatePurchase fonksiyonu satın almayı başlatır.
                m_StoreController.InitiatePurchase(product);
            }

            else
            {
                Debug.Log("Satın alırken hata oluştu, Ürün bulunamıyor, ürün yok");
            }
        }

        else
        {

            Debug.Log("Ürün kod tanımsız veya ürün çağırılamıyor.");
        }
    }


    public void RestorePurchases()
    {
        // Satın alma henüz kurulmadıysa
        if (!IsInitialized())
        {
            Debug.Log("Geri Alım başarısız");
            return;
        }

        // Bir apple cihazında çalışıyorsak, satın alınan bir üründe hata olursa onu kurtarabiliyoruz.
        // bu şuanlık sadece apple tarafından desteklenmektedir. Burada cihazı sorguluyoruz.
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            // ... begin restoring purchases
            Debug.Log("Onarma, kurtarma Başladı");

            // Apple store özgü alt sistemi çağırıyoruz.
            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions((result) =>
            {
                // Geri yüklemeyi başlattı. Geri yükleme işleminin sonucunu döndürür.
                Debug.Log("Geri yükleme devam ediyor. Durum = : " + result);
            });
        }

        else
        {
            // Eğer cihazımın apple ürünü değilse burası dönecektir ve kullanılan platformu bize yazacaktır.
            Debug.Log("Geri yükleme başarısız, bu platform desteklenmiyor. Kullanılan Platfrom = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {

        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {

        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    // Burada satın alma işleminin, sürecini kontol ederiz.
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // Eğer gelen ürün id'si bizim sistemde tanımladığımız id'mize eşitse, satın alınan ürünü oyuncuya
        // verme yeri burasıdır. Burada ki amaç hangi ürünü satın aldığını anlamaktır.
        if (String.Equals(args.purchasedProduct.definition.id, mekik, StringComparison.Ordinal))
        {

            PlayerPrefs.SetInt("mekik6", 1);
            PlayerPrefs.Save();
        }


        /* gibi devam edebiliriz. 
         else if (String.Equals(args.purchasedProduct.definition.id, Elmas_10, StringComparison.Ordinal))
     {

         PlayerPrefs.SetInt("ElmasSayisi", PlayerPrefs.GetInt("ElmasSayisi") + 10);
         PlayerPrefs.Save();
     }

         */
        else
        {
            Debug.Log(string.Format("Başarısız, Tanınmayan bir ürün"));
        }


        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {

        Debug.Log(string.Format("Satın alma başarısız"));
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        throw new NotImplementedException();
    }
}
