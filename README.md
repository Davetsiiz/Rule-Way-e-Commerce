**Category**
- CategoryWithProducts 		=> Katagoriye bağlı şekilde ürünleri getirir.
- GetCategoryBySearch  		=> Kategori ismine göre arama yapar.
- All(GET) 				=> Tüm Kategorileri getirir.

**Product**
- All(GET)			=> Tüm Stokları Filtresiz olarak getirir
- GetById(GET)			=> Id ye göre stok getirir.
- Save(POST)			=> Ürün kaydı yapar.
- Update(PUT)			=> Ürün üzerinde güncelleme işlemi yapar.
- Remove(DELETE)			=> Ürünü siler
- GetProductWithCategory		=> Ürünü kategorisi ile beraber getirir.
- GetProductTitleBySearch	=> Ürün Başlığına göre arama yapar.
- GetProductDescriptionBySearch	=> Ürün Açıklamasına göre arama yapar.
- GetProductByStockQuantityRange => Ürün stok sayısını belli bir aralıkte getirilmesini sağlar.
- GetProductByCategoryMinStock	=> Categori düzeyinde belirlenmiş bir minimum stok değerinin üstünde olan ürünleri gösterir.

