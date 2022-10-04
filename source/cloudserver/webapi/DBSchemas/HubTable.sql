-- Create Schemafull Table
define table hub Schemafull;

-- Set Fields in table
define field name on table hub type string;
DEFINE FIELD mac ON hub TYPE string;
Define field home on hub type record(home);
define field private_addr on table hub type string;
define field public_addr on table hub type string;