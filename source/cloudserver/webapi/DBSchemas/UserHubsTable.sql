-- Create Schemafull Table
define table userhubs Schemafull;

-- Set Fields in table
define field uid on table user type string;
define field user_id on table hub type int;
define field hub_id on table hub type int;

-- Set Unique ID
define index uid on table hub columns uid unique;