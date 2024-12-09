SELECT * FROM MDB_SYS_SCREEN_USER WHERE  SCREEN_CD = 'CF-CTL-CMT-001'

SELECT * FROM   Mdb_Cus_Comment

SELECT		C.Cus_Comment_ID, C.Cus_No, C.Comment_Type_ID, CT.Comment_Type_Desc, 
 RTRIM(C.Cus_Comment) AS Cus_Comment, 
 ISNULL(C.Comment_Order, 0) AS Comment_Order, 
 RTRIM(C.User_Login) AS User_Login, C.Update_TS 
 FROM		MDB_CUS_COMMENT C WITH (Nolock) 
INNER JOIN MDB_CFG_COMMENT_TYPE CT WITH (Nolock) ON C.Comment_Type_ID = CT.Comment_Type_ID
WHERE		C.Cus_No = 'USC752'
ORDER BY	ISNULL(C.Comment_Order, 0) 