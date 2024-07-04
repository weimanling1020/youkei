CREATE OR REPLACE FUNCTION public.sp_common_getname(tablename_in character varying, codeitemname_in character varying, nameitemname_in character varying, maincode_in character varying, subcode_in character varying, code_in character varying)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$ 
declare labelname character varying;
BEGIN     
CASE 

  --名称マスタ
  WHEN tablename_in = 'tm_afmeisyo' THEN
     SELECT nm INTO labelname 
     FROM tm_afmeisyo WHERE nmmaincd = maincode_in AND nmsubcd = subcode_in AND nmcd = code_in;
     
  --汎用マスタ
  WHEN tablename_in = 'tm_afhanyo' THEN
     SELECT nm INTO labelname 
     FROM tm_afhanyo WHERE hanyomaincd = maincode_in AND hanyosubcd = subcode_in AND hanyocd = code_in;
     
  --医療機関マスタ
  WHEN tablename_in = 'tm_afkikan' THEN
     SELECT kikannm INTO labelname 
     FROM tm_afkikan WHERE kikancd = code_in;
     
  --宛名テーブル（住民）
  WHEN tablename_in = 'tt_afatena' THEN
     SELECT simei INTO labelname 
     FROM tt_afatena WHERE atenano = code_in;
          
  --ユーザマスタ
  WHEN tablename_in = 'tm_afuser' THEN
     SELECT usernm INTO labelname 
     FROM tm_afuser WHERE userid = code_in; 
  
  --未完成の場合   
  ELSE
     RETURN '未対応';
     
END CASE;                                      
     
 
RETURN labelname;

END;
$function$
