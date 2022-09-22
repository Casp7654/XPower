-- Test Data
relate user:1->userhubs->hub:1;
relate user:2->userhubs->hub:2;

-- select example
select id, ->userhubs->hub as hubs from user;