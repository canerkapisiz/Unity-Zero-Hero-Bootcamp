## İkinci Ödev Yapılanlar
  * 2 tane Script oluşturdum. 'AudioManager' ve 'GameManager'
  * MenuControlles scriptinde yazdığınız sound ile iligli kodları kullanarak AudioManager scriptini yazdım.
  * MainMenu Sahnesi kapandığında AudioManager scriptimin kapanamması için DontDestroyOnLoad methodunu kullandım.
  * Game Scene sahnesinde MainMenu Sahnesinde yaptığınız sound ayarları panelini Game Sahneme kopyaladım.
  * Game Scene için GameManager scripti oluşturdum. Game Scene deki slider ve reset tuşlarını kontrol edip AudioManager scriptine değerler dönderdim.
  * Sonuç olarak MainMenu Sahnesinden, Game Sahnesine geçişte clip kesilmeden devam ediyor. Game Sahnesindeki Panelden slider ile clip'in volume değerini değiştirilebiliyoruz. Reset tuşuyla volume değerini 1'e getirebiliyoruz.
