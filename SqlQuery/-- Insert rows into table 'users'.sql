-- Insert rows into table 'users'
INSERT INTO users
( -- columns to insert data into
 [FirstName], [LastName], [Email], [Password]
)
VALUES
( -- first row: values for the columns in the list above
 'Mahmut', 'TUNCER', 'mahmut@tuncer.com','12345'
),
( -- second row: values for the columns in the list above
 'İsmail', 'TÜRÜT', 'ismail@turut.com','12345'
),
(
    'Nihat','DOĞAN','nihat@dogan.com','12345'
)
-- add more rows here
GO