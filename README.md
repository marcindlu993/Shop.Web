# Shop.Web
Zadanie rekrutacyjne

1. Zadanie można uruchomić na stronie:
sklep: http://marcindlu993-001-site3.ftempurl.com/
Web API: http://marcindlu993-001-site4.ftempurl.com/help (informacje w języku angielskim)

GitHub zadania, kod:
Sklep, oraz WebApi(obecny link): https://github.com/marcindlu993/Shop.Web/

Projekt można pobrać i umieścić na serwerze poprzez publikację w środowisku Visual Studio. Jednak mam nadzieję że umieszczone 
wyżej linki są wystarczające do sprawdzenia zadania.

2. Web API
W celu pobrania wszystkich danych uporządkowanych alfabetycznie z bazy należy użyć adresu
http://marcindlu993-001-site4.ftempurl.com/api/resources

W celu pobrania danych z bazy na podstawie frazy zawartej w rodzaju książki, tytule lub wydawnictwie należy użyć adresu
http://marcindlu993-001-site4.ftempurl.com/api/resources/{fraza}
gdzie {fraza} to wyraz wg którego dane zostaną przefitrowane.

3
Wykorzystane technologie/wzorce:

ASP.NET MVC - cały projekt jest wykonany w tej technologii. Wykorzystanie wzorca MVC najlepiej widać w kontekście koszyka:
Model - Models/CartModel.cs - cała logika dodawania produktów, liczenia łącznej kwoty, ilości produktów, zwracanie zawartości koszyka.
View - Views/Cart - widoki koszyka
Controller - Controllers/CartController.cs - metody pobierające dane z bazy i umieszczające dane w koszyku (w sesji), 
  lub wysyłające dane do widoków.
--------------------------------------------------------------
C# - wszystkie modele, kontrolery zostały napisane w tym języku
--------------------------------------------------------------
MS SQL - do przechowywania danych została wykorzystana baza MS SQL. 
--------------------------------------------------------------
Entity Framework - - baza danych zbudowana na podstawie modeli np. Models/CartModels.cs, i Models/ResourceModels.cs
--------------------------------------------------------------
Web API - etap 5 Web API 
--------------------------------------------------------------
JavaScript - z wykorzystaniem technologii AJAX widok View/Cart/AddToCart.cshtml
--------------------------------------------------------------
CSS - folder Content, projekt stworzony na podstawie Bootstrap z niewielkimi poprawkami w pliku Site.css, oraz w widokach
--------------------------------------------------------------

4.Komentarze odnośnie zadania:
Przydałaby się weryfikacja dla administratora strony i udostępnienie mu prostego CRUD'a do zarządzania produktami.
