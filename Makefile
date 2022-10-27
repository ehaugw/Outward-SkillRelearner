modname = SkillRelearner
gamepath = /mnt/c/Program\ Files\ \(x86\)/Steam/steamapps/common/Outward
pluginpath = BepInEx/plugins

assemble:
	rm -f -r public
	mkdir -p public/$(pluginpath)/$(modname)
	cp bin/$(modname).dll public/$(pluginpath)/$(modname)/

publish:
	make assemble
	rm -f $(modname).rar
	rar a $(modname).rar -ep1 public/*

install:
	make assemble
	rm -r -f $(gamepath)/$(pluginpath)/$(modname)
	cp -r public/* $(gamepath)
clean:
	rm -f -r public
	rm -f $(modname).rar
	rm -f -r bin
info:
	echo Modname: $(modname)