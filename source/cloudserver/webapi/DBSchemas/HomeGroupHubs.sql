-- Test Data
relate homegroup:1->grouphubs->hub:1;
relate homegroup:2->grouphubs->hub:2;

-- select example
select id, ->grouphubs->hub as hubs from homegroup:1;