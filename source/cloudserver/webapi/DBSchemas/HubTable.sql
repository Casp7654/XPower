-- Create Schemafull Table
define table hub Schemafull;

-- Set Fields in table
define field uid on table user type string;
define field id on table hub type int;
define field name on table hub type string;
define field network on table hub type object;
define field network.private_addr on table hub type string;
define field network.public_addr on table hub type string;

-- Set Unique ID
define index uid on table hub columns uid unique;