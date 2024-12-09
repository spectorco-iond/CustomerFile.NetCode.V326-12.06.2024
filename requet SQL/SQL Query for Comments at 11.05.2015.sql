
select top 100 * from Mdb_Prog_Comment order by PROG_COMMENT_ID  desc

select * from Mdb_Prog_Comment where CUS_PROG_ID = 6514 order by PROG_COMMENT_ID desc


SELECT ISNULL(P.Prog_Comment_ID, 0) as Prog_Comment_ID, P.CUS_PROG_ID, P.MESSAGE_ID, 0 as CHECK_VALUE, 
  '' AS MESSAGE_DESC, ISNULL(P.COMMENT_DESC, '') AS COMMENT_DESC, P.USER_LOGIN, P.UPDATE_TS FROM 
  MDB_Prog_Comment P WHERE  P.CUS_PROG_GUID = '0de3d8d5-fe42-48a6-82d9-83a3c5480ce9' 
  AND P.CUS_PROG_ITEM_LIST_GUID = '43e84ae5-3faa-4bee-8480-4bf8d2a0f49b'  AND ISNULL(COMMENT_DESC, '') <> '' 
  
select * from MDB_MESSAGE_DESC_VIEW where MSG_GROUP = 'General and Pricing' 


select * from MDB_CUS_PROG where SPECTOR_CD = 'Q14-0012'
  select * from mdb_cus_prog_quote_view where CUS_PROG_ID = 3044
  
  SELECT  DISTINCT CASE WHEN ISNULL(P.COMMENT_DESC, '') = '' THEN M.MESSAGE_DESC ELSE P.COMMENT_DESC END AS COMMENT_DESC
  FROM  MDB_MESSAGE_DESC_VIEW M LEFT JOIN MDB_Prog_Comment P WITH (NOLOCK) ON M.MESSAGE_ID = P.MESSAGE_ID
  WHERE  M.TAAL_CD = 'EN' AND    P.CUS_PROG_GUID = '2dbc14de-9ec9-4418-9fb2-eb32f99709fc' AND   
  ISNULL(Prog_Comment_ID, 0) <> 0 AND    ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') IN ('154c6e86-c2d9-4fcb-898d-43d8183a0596', '0', '0')
  UNION   
  SELECT DISTINCT ISNULL(P.COMMENT_DESC, '') AS COMMENT_DESC FROM  MDB_Prog_Comment P WITH (NOLOCK) 
  WHERE P.CUS_PROG_GUID = '2dbc14de-9ec9-4418-9fb2-eb32f99709fc' 
  AND ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') IN ('154c6e86-c2d9-4fcb-898d-43d8183a0596', '0', '0') 
  AND ISNULL(P.COMMENT_DESC, '') <> '' AND P.MESSAGE_ID = 0 ORDER BY COMMENT_DESC 


 
select * from MDB_MESSAGE_DESC_VIEW where MSG_GROUP = 'General and Pricing' and TAAL_CD = 'EN' and MESSAGE_ID = 2
union
select * from MDB_MESSAGE_DESC_VIEW where MSG_GROUP = 'Decoration / Packaging' and TAAL_CD = 'EN' and MESSAGE_ID = 2
union
select * from MDB_MESSAGE_DESC_VIEW where MSG_GROUP = 'Shipping / samples / approvals' and TAAL_CD = 'EN' and MESSAGE_ID = 17



SELECT  DISTINCT PROG_COMMENT_ID, ISNULL(P.COMMENT_DESC, '') AS COMMENT_DESC ,'' As MSG_GROUP,0 As  MSG_ORDER FROM  
 MDB_Prog_Comment P WITH (NOLOCK) WHERE      P.CUS_PROG_GUID = '2dbc14de-9ec9-4418-9fb2-eb32f99709fc'
 AND ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') = '' AND  ISNULL(P.ITEM_CD, '') = '' AND ISNULL(P.COMMENT_DESC, '') <> ''
 AND P.MESSAGE_ID = 0
UNION
SELECT  DISTINCT 0 AS PROG_COMMENT_ID, CASE WHEN ISNULL(P.COMMENT_DESC, '') = '' THEN M.MESSAGE_DESC ELSE P.COMMENT_DESC END
 AS COMMENT_DESC,M.MSG_GROUP, M.MSG_ORDER FROM  MDB_MESSAGE_DESC_VIEW M LEFT JOIN MDB_Prog_Comment P
 WITH (NOLOCK) ON M.MESSAGE_ID = P.MESSAGE_ID WHERE  M.TAAL_CD = 'EN' AND M.MSG_GROUP = 'General and Pricing' AND
 P.CUS_PROG_GUID = '2dbc14de-9ec9-4418-9fb2-eb32f99709fc' AND    ISNULL(Prog_Comment_ID, 0) <> 0 AND 
 ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') = '' AND    ISNULL(P.ITEM_CD, '') = ''
 UNION 
SELECT  DISTINCT 0 AS PROG_COMMENT_ID, CASE WHEN ISNULL(P.COMMENT_DESC, '') = '' THEN M.MESSAGE_DESC ELSE P.COMMENT_DESC END
 AS COMMENT_DESC,M.MSG_GROUP, M.MSG_ORDER FROM  MDB_MESSAGE_DESC_VIEW M LEFT JOIN MDB_Prog_Comment P
 WITH (NOLOCK) ON M.MESSAGE_ID = P.MESSAGE_ID WHERE  M.TAAL_CD = 'EN' AND M.MSG_GROUP = 'Decoration / Packaging' AND
 P.CUS_PROG_GUID = '2dbc14de-9ec9-4418-9fb2-eb32f99709fc' AND    ISNULL(Prog_Comment_ID, 0) <> 0 AND 
 ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') = '' AND    ISNULL(P.ITEM_CD, '') = ''
 UNION 
 SELECT  DISTINCT 0 AS PROG_COMMENT_ID, CASE WHEN ISNULL(P.COMMENT_DESC, '') = '' THEN M.MESSAGE_DESC ELSE P.COMMENT_DESC END
 AS COMMENT_DESC, M.MSG_GROUP, M.MSG_ORDER FROM  MDB_MESSAGE_DESC_VIEW M LEFT JOIN MDB_Prog_Comment P
 WITH (NOLOCK) ON M.MESSAGE_ID = P.MESSAGE_ID WHERE  M.TAAL_CD = 'EN' AND M.MSG_GROUP = 'Shipping / samples / approvals' AND
 P.CUS_PROG_GUID = '2dbc14de-9ec9-4418-9fb2-eb32f99709fc' AND    ISNULL(Prog_Comment_ID, 0) <> 0 AND 
 ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') = '' AND    ISNULL(P.ITEM_CD, '') = ''
 order by MSG_ORDER-- PROG_COMMENT_ID, COMMENT_DESC 

SELECT  DISTINCT PROG_COMMENT_ID, ISNULL(P.COMMENT_DESC, '') AS COMMENT_DESC ,0 As  MSG_ORDER FROM  
 MDB_Prog_Comment P WITH (NOLOCK) WHERE      P.CUS_PROG_GUID = '2dbc14de-9ec9-4418-9fb2-eb32f99709fc'
 AND ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') = '' AND  ISNULL(P.ITEM_CD, '') = '' AND ISNULL(P.COMMENT_DESC, '') <> ''
 AND P.MESSAGE_ID = 0
UNION
SELECT  DISTINCT 0 AS PROG_COMMENT_ID, CASE WHEN ISNULL(P.COMMENT_DESC, '') = '' THEN M.MESSAGE_DESC ELSE P.COMMENT_DESC END
 AS COMMENT_DESC, M.MSG_ORDER FROM  MDB_MESSAGE_DESC_VIEW M LEFT JOIN MDB_Prog_Comment P
 WITH (NOLOCK) ON M.MESSAGE_ID = P.MESSAGE_ID WHERE  M.TAAL_CD = 'EN'  AND
 P.CUS_PROG_GUID = '2dbc14de-9ec9-4418-9fb2-eb32f99709fc' AND    ISNULL(Prog_Comment_ID, 0) <> 0 AND 
 ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') = '' AND    ISNULL(P.ITEM_CD, '') = ''
 order by MSG_ORDER
 
 
 SELECT  DISTINCT ISNULL(P.COMMENT_DESC, '') AS COMMENT_DESC, 0 As  MSG_ORDER, Prog_Comment_ID  FROM 
 MDB_Prog_Comment P WITH (NOLOCK)  WHERE P.CUS_PROG_GUID = '39b0f673-b234-470d-a817-6d0fbb7b500c' 
 AND  ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') IN ('4b068d21-97b5-49df-a6e1-500a311175b7') 
 AND ISNULL(P.COMMENT_DESC, '') <> '' AND P.MESSAGE_ID = 0 
 UNION
 SELECT DISTINCT CASE WHEN ISNULL(P.COMMENT_DESC, '') = '' THEN M.MESSAGE_DESC ELSE P.COMMENT_DESC END AS COMMENT_DESC,
 M.MSG_ORDER, '' As PROG_COMMENT_ID  FROM MDB_MESSAGE_DESC_VIEW M  LEFT JOIN MDB_Prog_Comment P WITH (NOLOCK) ON M.MESSAGE_ID = P.MESSAGE_ID 
 WHERE  M.TAAL_CD = 'EN' AND    P.CUS_PROG_GUID = '39b0f673-b234-470d-a817-6d0fbb7b500c' 
 AND ISNULL(Prog_Comment_ID, 0) <> 0 AND ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') IN ('4b068d21-97b5-49df-a6e1-500a311175b7')
 order by MSG_ORDER  asc, PROG_COMMENT_ID asc



--last comments 

SELECT  DISTINCT PROG_COMMENT_ID, ISNULL(P.COMMENT_DESC, '') AS COMMENT_DESC, 0 As MSG_ORDER,
Prog_Comment_ID FROM  MDB_Prog_Comment P WITH (NOLOCK) WHERE P.CUS_PROG_GUID = 'caa8ff62-72de-4a87-96f2-c9a1ce88a053' 
AND ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') = '' AND ISNULL(P.ITEM_CD, '') = '' AND ISNULL(P.COMMENT_DESC, '') <> ''
AND P.MESSAGE_ID = 0  
UNION
SELECT DISTINCT 0 AS PROG_COMMENT_ID, 
CASE WHEN ISNULL(P.COMMENT_DESC, '') = '' THEN M.MESSAGE_DESC ELSE P.COMMENT_DESC END AS COMMENT_DESC,
M.MSG_ORDER, '' As PROG_COMMENT_ID  FROM  MDB_MESSAGE_DESC_VIEW M LEFT JOIN MDB_Prog_Comment P WITH (NOLOCK)
ON M.MESSAGE_ID = P.MESSAGE_ID WHERE  M.TAAL_CD = 'EN' AND P.CUS_PROG_GUID = 'caa8ff62-72de-4a87-96f2-c9a1ce88a053' 
AND ISNULL(Prog_Comment_ID, 0) <> 0 AND    ISNULL(P.CUS_PROG_ITEM_LIST_GUID, '') = '' AND ISNULL(P.ITEM_CD, '') = ''
order by MSG_ORDER asc, P.PROG_COMMENT_ID asc "
