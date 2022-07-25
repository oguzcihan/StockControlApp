# User Guide
- Proje master branch inden clone işlemi tamamlandıktan sonra Visual Studio 2022 Community Idesiye proje açılır. 
- Proje açıldıktan sonra Core katmanı içerisinde bulunan Constants klasöründen Constants Class'ı açılmalı ve buradaki database connection string alanını kendi database adresinize göre ayarlamalısınız. Database yolu ayarlandıktan sonra sırasıyla:

- Visual Studio da Package Manager Console açılır.
- PM de default project StockControl.Data yapılır.
- StockControl.Data seçildikten sonra mevcut migration lar veritabanına gönderilmek için 'Update-Database' kodu çalıştırılır.
- Database oluştuğuna dair 'Done' bildirimi görüldükten sonra Startup Project olarak StockControlApp seçilir.
- Startup project ayarlandıktan sonra proje çalıştırılır.
