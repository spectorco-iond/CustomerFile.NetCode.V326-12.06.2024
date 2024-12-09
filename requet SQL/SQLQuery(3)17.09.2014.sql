  
  SELECT	C.debnr,C.CUS_NO, C.CUS_NAME, C.ADDR_1, C.ADDR_2, C.ADDR_3, C.CITY, 
                       C.STATE, C.ZIP, C.COUNTRY, C.PHONE_NO, C.SLSPSN_NO, 
                      S.SLSPSN_NAME AS SLSPSN_NO_DESC, C.CUS_NOTE_1, P.CLASSIFICATIONID, 
                       C.CUS_NOTE_3, C.TXBL_FG, C.ALLOW_BO, C.ALLOW_PART_SHIP 
            FROM		ARCUSFIL_SQL C 
            LEFT JOIN	ARSLMFIL_SQL S ON C.SLSPSN_NO = S.HUMRES_ID 
            LEFT JOIN  CICMPY P ON C.CUS_NO = P.CMP_CODE 
            where cus_note_3 LIKE '%STAPLES%'
            ORDER BY	C.CUS_NO 
            
 SELECT *
          FROM		ARCUSFIL_SQL C where slspsn_no = '414'
 SELECT * 
          FROM      ARSLMFIL_SQL  where humres_id = '414' /*AccountEmployeeId and SalesPersonNuber*/
 SELECT * 
	      FROM      CICMPY   where cmp_code = 'USC752'      
            
            
            LEFT JOIN	ARSLMFIL_SQL S ON C.SLSPSN_NO = S.HUMRES_ID WHERE cus_note_3 like '%STAPL%'
            LEFT JOIN  CICMPY P ON C.CUS_NO = P.CMP_CODE 
            where cus_note_3 LIKE '%STAPLE%'
            ORDER BY	C.CUS_NO
             cus_no,	cus_note_3, cus_name 