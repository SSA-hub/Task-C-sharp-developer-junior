CREATE TABLE product (
  p_id integer PRIMARY KEY,
  name text
);
create Table category (
  c_id integer PRIMARY key,
  name text
);
CREATE table product_categories (
  product integer FOREIGN KEY REFERENCES product(p_id),
  category integer FOREIGN KEY REFERENCES category(c_id),
  PRIMARY key (product, category)
);

INSERT into product(p_id, name) VALUES(1, 'Apple');
INSERT into product(p_id, name) VALUES(2, 'Pineapple');
INSERT into product(p_id, name) VALUES(3, 'Lada Priora');
INSERT into product(p_id, name) VALUES(4, 'Airbus');

INSERT into category(c_id, name) VALUES(1, 'Fruits');
INSERT into category(c_id, name) VALUES(2, 'Cars');
INSERT into category(c_id, name) VALUES(3, 'Green');

INSERT into product_categories(product, category) values(1, 1), (1, 3), (2, 1), (3, 2);

select p.name, c.name from product AS p
	LEFT JOIN product_categories as pc on p.p_id = pc.product
    Left join category as c on pc.category = c.c_id;