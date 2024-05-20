## İkinci Ödev Yapılanlar
  * 2 tane Scrıpt oluşturdum. 'AudioManager' ve 'GameManager'
  * MenuControlles scriptinde yazdığınız sound ile iligli kodları kullanarak AudioManager scriptini yazdım.
  * MeinMenu Sahnesı kapandığında AudioManager scriptimin kapanamması için DontDestroyOnLoad methodunu kullandım.
  * Game Scene sahnesinde MeinMenu Sahnesinde yaptığını sound ayarları paneli Game Scene Kopyaladım.
  * Game Scene için GameManager scripti oluşturdum. Game Scene deki slider ve reset tuşlarını kontrol edip AudioManager scriptine değerler dönderdim.
  * Sonuç olarak MeinMenu Sahnesinden, Game Sahnesinde geçişte sound kesilmeden devam ediyor. Game Sahnesindeki Panelden slider ile sound un volume değerini değistirilebiliyoruz. Reset tuşuyla volume değerini 1'e getiriyoruz.
