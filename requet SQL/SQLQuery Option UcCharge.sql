SELECT * FROM MDB_SYS_SCREEN_USER WHERE  SCREEN_CD = 'CF-CTL-CHG-001' AND  SCREEN_USER = 'iond'

SELECT		C.CHARGE_ID, ISNULL(CU.CHARGE_USAGE_ID, 0) AS CHARGE_USAGE_ID, C.SHORT_DESC, CU.CUS_NO, " & _
            "			CONVERT(BIT, (CASE ISNULL(CU.ALWAYS_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS ALWAYS_USE, " & _
            "			CONVERT(BIT, (CASE ISNULL(CU.NEVER_USE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS NEVER_USE, " & _
            "			CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 1 ELSE 0 END)) AS WAIVED, " & _
            "			CONVERT(BIT, (CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN 0 ELSE 1 END)) AS NOT_WAIVED, " & _
            "           CASE ISNULL(CU.NO_CHARGE, 0) WHEN 1 THEN CONVERT(VARCHAR(10), '')  ELSE CONVERT(VARCHAR(10), CU.UNIT_PRICE) END AS UNIT_PRICE, " & _
            "           CU.WHEN_QTY_LT, CU.WHEN_QTY_GT, CU.WHEN_AMT_LT, CU.WHEN_AMT_GT, " & _
            "           CU.SEND_EMAIL, CU.EMAIL_TO, CU.WHEN_REQ, CU.BLIND, CU.COMMENTS, CU.AUTORIZED_BY " & _
            "FROM " & _
            "   (	SELECT	CUS.CUS_NO, C.* " & _
            "       FROM	arcusfil_sql CUS WITH (Nolock), MDB_CFG_CHARGE C WITH (Nolock) " & _
            "	) C " & _
            "LEFT JOIN	MDB_CFG_CHARGE_USAGE CU WITH (NOLOCK) ON c.charge_id = cu.CHARGE_ID and c.cus_no = cu.cus_no " & _
            "INNER JOIN	MDB_CFG_CHARGE CH WITH (NOLOCK) ON CU.CHARGE_ID = CH.CHARGE_ID " & _
            "LEFT JOIN  MDB_CUS_PROG CP WITH (NOLOCK) ON CU.CUS_NO = CP.CUS_NO AND CU.CUS_PROG_ID = CP.CUS_PROG_ID AND ISNULL(CP.PROG_TYPE, 0) IN (0, 4) " & _
            "WHERE		C.CUS_NO = '" & m_Customer.cmp_code & "' AND (CU.charge_usage_id IS NOT NULL) AND CP.PROG_TYPE = 4 "