-- Create Schemafull Table
define table user Schemafull;

-- Set Fields in table
define field username on table user type string;
define field email on table user type string;
define field firstname on table user type string;
define field lastname on table user type string;
define field hashed_password on table user type string;
define field salt on table user type string;