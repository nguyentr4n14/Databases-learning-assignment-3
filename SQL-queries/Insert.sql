INSERT INTO
    categories (category_id, category_name, parent_category_id)
VALUES
    (1, 'Electronics', NULL),
    (2, 'Mobile Phones', 1),
    (3, 'Laptops', 1),
    (4, 'Accessories', NULL);

INSERT INTO
    customers (
        customer_id,
        first_name,
        last_name,
        email,
        phone,
        created_at,
        updated_at
    )
VALUES
    (
        1,
        'Ola',
        'Nordmann',
        'ola.nordmann@example.com',
        '(+47) 12345678',
        '2025-01-01 10:00:00',
        '2025-01-01 10:00:00'
    ),
    (
        2,
        'Anna',
        'Svensson',
        'anna.svensson@example.com',
        '(+46) 98765432',
        '2025-01-02 11:00:00',
        '2025-01-02 11:00:00'
    );

INSERT INTO
    addresses (
        address_id,
        customer_id,
        street,
        city,
        state,
        postal_code,
        country,
        address_type
    )
VALUES
    -- Customer 1 (Ola Nordmann) in Norway
    (
        1,
        1,
        'Karl Johans gate 15',
        'Oslo',
        'Oslo',
        '0159',
        'Norway',
        'shipping'
    ),
    (
        2,
        1,
        'Universitetsgata 20',
        'Oslo',
        'Oslo',
        '0162',
        'Norway',
        'billing'
    ),
    -- Customer 2 (Anna Svensson) in Sweden
    (
        3,
        2,
        'Drottninggatan 50',
        'Stockholm',
        'Stockholm',
        '11121',
        'Sweden',
        'shipping'
    ),
    (
        4,
        2,
        'Kungsgatan 70',
        'Stockholm',
        'Stockholm',
        '11122',
        'Sweden',
        'billing'
    );

INSERT INTO
    stores (
        store_id,
        store_name,
        phone,
        email,
        street,
        city,
        postal_code,
        country
    )
VALUES
    (
        1,
        'Gothenburg Store',
        '(+46) 555-1000',
        'gothenburg@example.com',
        'Avenyn 10',
        'Gothenburg',
        '41136',
        'Sweden'
    ),
    (
        2,
        'Helsinki Store',
        '(+358) 555-2000',
        'helsinki@example.com',
        'Mannerheimintie 20',
        'Helsinki',
        '00100',
        'Finland'
    );

INSERT INTO
    staff (
        staff_id,
        first_name,
        last_name,
        email,
        phone,
        store_id
    )
VALUES
    -- Sanna works at the Helsinki Store (store_id=2)
    (
        1,
        'Sanna',
        'Laine',
        'sanna.laine@example.com',
        '(+358) 555-1010',
        2
    ),
    -- Erik works at the Gothenburg Store (store_id=1)
    (
        2,
        'Erik',
        'Johansson',
        'erik.johansson@example.com',
        '(+46) 555-2020',
        1
    );

INSERT INTO
    products (
        product_id,
        product_name,
        description,
        price,
        created_at,
        updated_at
    )
VALUES
    (
        1,
        'Smartphone X',
        'Latest flagship smartphone',
        799.99,
        '2025-01-03 09:00:00',
        '2025-01-03 09:00:00'
    ),
    (
        2,
        'Laptop Pro',
        'High-end business laptop',
        1299.00,
        '2025-01-03 09:10:00',
        '2025-01-03 09:10:00'
    ),
    (
        3,
        'Wireless Headphones',
        'Noise-cancelling headphones',
        199.50,
        '2025-01-03 09:20:00',
        '2025-01-03 09:20:00'
    );

INSERT INTO
    product_categories (category_id, product_id)
VALUES
    (2, 1),
    -- Smartphone X => Mobile Phones
    (1, 1),
    -- Smartphone X => Electronics
    (3, 2),
    -- Laptop Pro   => Laptops
    (4, 3);

-- Headphones   => Accessories
INSERT INTO
    orders (
        order_id,
        customer_id,
        order_date,
        order_status,
        shipping_address_id,
        billing_address_id
    )
VALUES
    -- Ola Nordmann
    (1, 1, '2025-02-01 08:30:00', 'Pending', 1, 2),
    -- Anna Svensson
    (2, 2, '2025-02-02 09:00:00', 'Shipped', 3, 4);

INSERT INTO
    order_items (
        order_id,
        product_id,
        quantity,
        unit_price,
        discount
    )
VALUES
    -- Order #1
    (1, 1, 1, 799.99, 0.00),
    -- 1x Smartphone X
    (1, 3, 1, 199.50, 0.00),
    -- 1x Wireless Headphones
    -- Order #2
    (2, 2, 1, 1299.00, 100.00),
    -- 1x Laptop Pro with discount
    (2, 3, 2, 199.50, 0.00);

-- 2x Wireless Headphones
INSERT INTO
    stocks (
        store_id,
        product_id,
        quantity_in_stock,
        updated_at
    )
VALUES
    -- Gothenburg Store (1)
    (1, 1, 50, '2025-01-05 10:00:00'),
    -- 50 units of Smartphone X
    (1, 2, 30, '2025-01-05 10:00:00'),
    -- 30 units of Laptop Pro
    (1, 3, 20, '2025-01-05 10:00:00'),
    -- 20 units of Headphones
    -- Helsinki Store (2)
    (2, 1, 40, '2025-01-05 10:00:00'),
    -- 40 units of Smartphone X
    (2, 2, 15, '2025-01-05 10:00:00'),
    -- 15 units of Laptop Pro
    (2, 3, 25, '2025-01-05 10:00:00');

-- 25 units of Headphones