SELECT
  products.name,
  categories.name
FROM products
JOIN products_categories
  ON products.id = products_categories.products_id
JOIN categories
  ON categories.id = products_categories.categories_id;