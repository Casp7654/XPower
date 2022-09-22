-- Create Schemafull Table
define table hub Schemafull;

-- Set Fields in table
define field name on table hub type string;
define field private_addr on table hub type string;
define field public_addr on table hub type string;

-- Test Data
insert into hub {id:1, name:"hub1", private_addr:"172.64.0.3", public_addr:"172.32.0.2" };
insert into hub {id:2, name:"hub2", private_addr:"172.64.0.15", public_addr:"172.32.0.2" };