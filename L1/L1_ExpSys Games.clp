(deffunction ask-value (?question)
    (print ?question)
    (bind ?answer (read))
    ?answer
    )

(deffunction ask-question (?question $?allowed-values)
    (print ?question)
    (bind ?answer (read))
    (if (lexemep ?answer) 
        then (bind ?answer (lowcase ?answer))
	    )
    (while (not (member$ ?answer ?allowed-values)) do
        (print ?question)
        (bind ?answer (read))
        (if (lexemep ?answer) 
            then (bind ?answer (lowcase ?answer))
		    )
	    )
    ?answer
    )

(deffunction yes-or-no (?question)
    (bind ?response (ask-question ?question yes no y n))
    (if (or (eq ?response yes) (eq ?response y))
        then yes 
        else no
	    )
    )
(defrule determenite-internet
    (not (internet ?))
	(not (tales-of-berseria ?))
	(not (valheim ?))
	(not (minecraft ?))
    =>
    (assert (internet (yes-or-no "Do you have an internet connection?: ")))
    )
	
(defrule determenite-number-of-players
    (not (players ?))
	(not (tales-of-berseria ?))
	(not (valheim ?))
	(not (minecraft ?))
    =>
    (assert (players (ask-value "How many players will play? ")))
    )

(defrule determenite-coop
    (not (coop ?))
	(internet yes)
    (players ?value)
    =>
    (if (and (< ?value 4) (> ?value 0))
        then (assert (coop yes))
        else (assert (coop no))
	    )
    )

(defrule determenite-online
    (not (online ?))
	(internet yes)
    (players ?value)
    =>
    (if  (> ?value 3)
        then (assert (online yes))
        else (assert (online no))
	    )
    )
	
(defrule determenite-solo
    (not (solo ?))
	(internet no)
    (players ?value)
    =>
    (if  (< ?value 2)
        then (assert (solo yes))
        else (assert (solo no))
	    )
    )
	
(defrule determenite-board-games
	(internet no)
	(players ?value)
    (not (board-games ?))
    =>
	(if  (> ?value 1)
        then (assert (board-games yes))
			(print "Try board games!" crlf)
	    )
    )
	
(defrule determenite-open-world
    (not (open-world ?))
	(not (go-for-a-walk ?))
    =>
    (assert (open-world (yes-or-no "Do you like open world games?: ")))
    )

(defrule determenite-survival
    (not (survival ?))
	(not (go-for-a-walk ?))
    =>
    (assert (survival (yes-or-no "Do you like survival simulators?: ")))
    )

(defrule determine-sandbox
    (and 
	    (open-world yes)
		(survival yes)
	    )
    (not (sandbox ?))
	(not (go-for-a-walk ?))
    =>
    (assert (sandbox yes))
	)

(defrule determenite-quest
    (not (quest ?))
	(not (go-for-a-walk ?))
    =>
    (assert (quest (yes-or-no "Do you like doing tasks and solving puzzles?: ")))
    )
	
(defrule determenite-rpg
    (and 
		(survival no)
		(quest yes)
	    )
	(not (rpg ?))
	(not (go-for-a-walk ?))
    =>
    (assert (rpg yes))
	)
    

(defrule determenite-rpg
    (and 
		(or(coop yes)
		(online yes))
		(quest yes)
	    )
	(not (rpg ?))
	(not (go-for-a-walk ?))
    =>
    (assert (rpg yes))
    )
	
(defrule determine-genshin-impact
    (and 
	    (rpg yes)
		(internet yes)
		(open-world yes)
	    )
    (not (genshin-impact ?))
	(not (go-for-a-walk ?))
    =>
    (assert (genshin-impact yes))
	(print "Try playing Genshin Impact!" crlf)
	)

(defrule determine-tales-of-berseria
    (or(and 
	    (rpg yes)
		(solo yes))
		(and 
		(open-world no)
		(quest yes)
		(or (internet yes)
			(internet no))))
	(players ?value)
	(not (genshin-impact ?))
    (not (tales-of-berseria ?))
	(not (go-for-a-walk ?))
    =>
	(if  (< ?value 2)
	then (assert (tales-of-berseria yes))
	(print "Try playing Tales of Berseria!" crlf)))
	
(defrule determenite-stategy
    (not (strategy ?))
	(not (go-for-a-walk ?))
	(not (genshin-impact ?))
	(not (tales-of-berseria ?))
    =>
    (assert (strategy (yes-or-no "Do you like team work?: ")))
    )
	
(defrule determenite-mythology
    (not (mythology ?))
	(not (go-for-a-walk ?))
	(not (genshin-impact ?))
	(not (tales-of-berseria ?))
    =>
    (assert (mythology (yes-or-no "Do you like mythology?: ")))
    )
	
(defrule determenite-moba
    (and 
		(or(coop yes)
		(online yes))
		(strategy yes)
	    )
	(not (moba ?))
	(not (go-for-a-walk ?))
    =>
    (assert (moba yes))
    )
	
(defrule determine-smite
	(and 
	    (moba yes)
		(mythology yes))
	
	(not (genshin-impact ?))
	(not (tales-of-berseria ?))
	(not (valheim ?))
    (not (smite ?))
	(not (go-for-a-walk ?))
    =>
    (assert (smite yes))
	(print "Try playing Smite!" crlf)
	)
	
(defrule determenite-valheim
    (and 
		(or(coop yes)
		(solo yes))
		(mythology yes)
		(sandbox yes)
	    )
	(not (genshin-impact ?))
	(not (tales-of-berseria ?))
	(not (valheim ?))
	(not (go-for-a-walk ?))
    =>
    (assert (valheim yes))
	(print "Try playing Valheim!" crlf)
    )

(defrule determenite-minecraft
    (and 
		(mythology no)
		(sandbox yes)
	    )
	(not (genshin-impact ?))
	(not (tales-of-berseria ?))
	(not (valheim ?))
	(not (minecraft ?))
	(not (go-for-a-walk ?))
    =>
    (assert (minecraft yes))
	(print "Try playing Minecraft!" crlf)
    )
	
(defrule determine-go-for-a-walk-2
	(and
		(survival no)
		(quest no)
		(mythology no)
		(strategy no)
		(or (internet no)
			(internet yes))
	)
    (not (go-for-a-walk ?))
	(not (board-games ?))
    =>
    (assert (go-for-a-walk yes))
	(print "Matching game not found!Go for a walk!" crlf)
	)


(defrule determine-nothing
	(not (minecraft ?))
	(not (genshin-impact ?))
	(not (tales-of-berseria ?))
	(not (valheim ?))
	(not (smite ?))
	(not (go-for-a-walk ?))
	(not (board-games ?))
	(or (internet yes)
	(internet no))
	(or (mythology yes)
	(mythology no))
    =>
    (assert (go-for-a-walk yes))
	(print "Looks like nothing worked for you. Think again what you might like or go for a walk." crlf)
	)