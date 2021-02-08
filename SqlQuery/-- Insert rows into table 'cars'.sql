-- Insert rows into table 'cars'
INSERT INTO cars
    ( -- columns to insert data into
    [BrandId], [ColourId], [CarModelName],[ModelYear],[DailyPrice],[Description]
    )
VALUES
    ( -- first row: values for the columns in the list above
        1, 5, 'Giulia', '2021-01-01 07:30:20', 250, 'Sesine hayran olduğum makina'
),
    ( -- second row: values for the columns in the list above
        1, 6, 'Giulietta', '2020-01-01 07:30:20', 200, 'tr için ideal fiyatlı olan :)'
),
    ( -- second row: values for the columns in the list above
        2, 1, 'E200', '2019-01-01 07:30:20', 200, 'Konfor arabası'
),
    ( -- second row: values for the columns in the list above
        2, 7, 'Vito', '2019-01-01 07:30:20', 200, 'Münübüs'
),
    ( -- second row: values for the columns in the list above
        6, 2, 'Egea', '2021-01-01 07:30:20', 150, 'şirket arabası'
),
    ( -- second row: values for the columns in the list above
        6, 3, 'Bravo', '2008-06-23 07:30:20', 100, 'güzel kaçar'
),
    ( -- second row: values for the columns in the list above
        4, 4, 'Passat', '2018-01-01 07:30:20', 500, 'seveni çok'
)
-- add more rows here
GO