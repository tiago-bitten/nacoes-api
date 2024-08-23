--#################################
--CONSULTA001 

SELECT * FROM voluntarios v
WHERE v.removido = 0
    AND EXISTS (
        SELECT 1 FROM voluntarios_ministerios vm
        WHERE vm.ministerio_id = @ministerio_id
            AND vm.voluntario_id = @voluntario_id
            AND vm.ativo = 1
    )
    AND (
        NOT EXISTS (
            SELECT 1 FROM agendamentos a
            WHERE a.voluntario_id = @voluntario_id
        )
        
        OR NOT (
            SELECT 1 FROM agendamentos a 
                WHERE a.agenda_id = @agenda_id
                    AND a.voluntario_id = @voluntario_id
                    AND a.removido = 0
        ) 
    )
  

--#################################

