-- Create Schemafull Table
define table user Schemafull;

-- Set Fields in table
define field username on table user type string;
define field email on table user type string;
define field name on table user type object;
define field name.first on table user type string;
define field name.last on table user type string;
define field hashed_password on table user type string;
define field salt on table user type string;

-- Test Data
insert into user {id:1, name:{first:'john', last:'doe'}, email:'heste@test.dk', username:"johnboi"};

insert into user {id:2, name:{first:'jane', last:'doe'}, email:'heste@test.dk', username:"janegurl"};