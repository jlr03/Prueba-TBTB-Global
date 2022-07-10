//Inserciones

INSERT INTO address (street, suit, city, zipcode, lat, `long`) VALUES ('Almorjon','asadasd', 'manizales','2558585an','58522255', '28225555');

INSERT INTO company (name, catchPhrase, bs) VALUES ('Fast','aslkdjaslkdjlaskdjasd', 'malskadasdkaslnizales');

INSERT INTO worker (username, email, addressId, phone, website, companyId) VALUES ('josebeap','josebeap@gmail.com', 4,'3215468745','josebeap.net', 4);

INSERT INTO worker (username, email, addressId, phone, website, companyId) VALUES ('juanito','juanito@gmail.com', 4,'3215467895','juanito.net', 4);

INSERT INTO worker (username, email, addressId, phone, website, companyId) VALUES ('jhon','jh@gmail.com', 4,'345789520','jhon.net', 4);

INSERT INTO worker (username, email, addressId, phone, website, companyId) VALUES ('angel','angel@gmail.com', 4,'3257892654','angel.net', 4);

INSERT INTO worker (username, email, addressId, phone, website, companyId) VALUES ('rose','rose@gmail.com', 4,'312868725','rose.net', 4);


//Consultas CRUD

select id,username,email, addressId, phone, website, companyId 
from worker;

delete from worker 
where id=@id;

update worker set 
username =@username,
email =@email,
addressId =@addressId ,
phone =@phone ,
website =@website ,
companyId =@companyId
where id =@id;

insert into worker 
(username,email,addressId,phone,website,companyId) 
values
(@username,@email,@addressId,@phone,@website,@companyId);

//Consultas Join

select a.username, a.email, b.street, a.phone, a.website, c.name
from worker as a
inner join address as b
on a.addressId = b.id
inner join company as c 
on a.companyId = c.id;

select a.username, a.email, a.addressId, a.phone, a.website, c.name
from worker as a
inner join company as c 
on a.companyId = c.id

