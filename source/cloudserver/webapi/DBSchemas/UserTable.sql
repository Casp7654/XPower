-- Create Schemafull Table
define table user Schemafull;

-- Set Fields in table
define field id on table user type int;
define field email on table user type string;
define field name on table user type object;
define field name.first on table user type string;
define field name.last on table user type string;
define fiels login on table user type object;
define fiels login.username on table user type string;
define fiels login.password on table user type string;

-- Set Unique ID
define index uid on table user columns uid unique;