-- Test Data
relate user:1->usergroups->homegroup:1;
relate user:2->usergroups->homegroup:1;

-- select example
select id, ->usergroups->homegroup as homegroups from user;