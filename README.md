# ReCapProject
Çok Katmanlı mimari yapısı ile hazırlanan, EntitiyFramework kullanılarak CRUD işlemlerinin yapıldığı, Console ve WebAPI arayüzü ile çalışan, Araç Kiralama iş yerlerine yönelik örnek bir projedir.


📚 Layers


Entities Layer :
Veritabanı tablolarının projede kullanılması için oluşturulmuş Entities Katmanı'nda Abstract ve Concrete olmak üzere iki adet ana klasör ve bunların dışında veritabanında olmayan ama projede linq sorguları için kullanılan DTOs klasörü bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.




Data Access Layer :
Veritabanı CRUD işlemleri gerçekleştirmek için oluşturulan Data Access Katmanı'nda Abstract ve Concrete olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur. Concrete Klasöründe farklı veritabanları ile çalışabilmek için alt klasörlere ayrılmıştır. Biz bu projemizde öncelikle InMemory'de çalıştık, daha sonra projeyi geliştirerek EntityFramework'e geçiş yaptık.



Business Layer :
Bu katmanda projeye ait iş kurallarımız bulunmaktadır. Sunum katmanından gelen bilgileri gerekli koşullara göre işlemek veya denetlemek için oluşturulan Business Katmanı'nda Abstract, Concrete, BusinessAspects, Constants, DependencyResolvers ve ValidationRules klasörlerimiz bulunmaktadır.




Core Layer :
Bir framework katmanı olan Core Katmanı'nda proje bağımsız tüm projelere entegre edebilmemizi sağlayan alt yapıyı kurmuş bulunuyoruz. Bu katmanda Aspects, CrossCuttingConcerns, DependencyResolvers, DataAccess, Entities, Utilities ve Extensions olmak üzere 7 adet klasör bulunmaktadır. Core katmanının .Net Core ile hiçbir bağlantısı yoktur.Oluşturulan core katmanında ortak kodlar tutulur. Core katmanı ile, kurumsal bir yapıda, alt yapı ekibi ilgilenir.




Console UI Layer :
Test ortamıdır. WebAPI tarafına geçmeden önce uygulamanın ne şekilde çalıştığı ve oluşturulan katmanların doğru çalışıp çalışmadı test edilir.




WebAPI Layer :
Projenin kullanıcı arayüzleri ile irtibata geçtiği katmandır. Front-end geliştiriciler bu API yapısını kullanarak projenin dış dünyaya sunumunu yapabilirler.
