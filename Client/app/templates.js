angular.module('sceiAdmin').run(['$templateCache', function($templateCache) {
  'use strict';

  $templateCache.put('template/footer.html',
    "Copyright &copy; - 2016 Controle para equipamentos de combate a incêndios."
  );


  $templateCache.put('template/header.html',
    "<ul class=\"header-inner clearfix\"><li id=\"menu-trigger\" data-target=\"mainmenu\" data-toggle-sidebar data-model-left=\"sceiAdmin.sidebarToggle.left\" data-ng-class=\"{ 'open': sceiCtrl.sidebarToggle.left === true }\"><div class=\"line-wrap\"><div class=\"line top\"></div><div class=\"line center\"></div><div class=\"line bottom\"></div></div></li><li class=\"logo\"><a data-ui-sref=\"home\" data-ng-click=\"sceiAdmin.sidebarStat($event)\">SCEI</a></li><li class=\"pull-right\"><ul class=\"top-menu\"></ul></li></ul>"
  );


  $templateCache.put('template/profile-menu.html',
    "<li class=\"btn-wave\" data-ui-sref-active=\"active\"><a data-ui-sref=\"pages.profile.profile-about\">About</a></li><li class=\"btn-wave\" data-ui-sref-active=\"active\"><a data-ui-sref=\"pages.profile.profile-timeline\">Timeline</a></li><li class=\"btn-wave\" data-ui-sref-active=\"active\"><a data-ui-sref=\"pages.profile.profile-photos\">Photos</a></li><li class=\"btn-wave\" data-ui-sref-active=\"active\"><a data-ui-sref=\"pages.profile.profile-connections\">Connections</a></li>"
  );


  $templateCache.put('template/sidebar-left.html',
    "<div class=\"sidebar-inner c-overflow\"><div class=\"profile-menu\"><a href=\"\" toggle-submenu><div class=\"profile-info\">{{sceiAdmin.usuarioLogado()}} <i class=\"zmdi zmdi-caret-down\"></i></div></a><ul class=\"main-menu\"><li><a data-ng-click=\"sceiAdmin.deslogar()\"><i class=\"zmdi zmdi-arrow-left\"></i> Sair</a></li><li data-ui-sref-active=\"active\" ng-show=\"sceiAdmin.usuarioPodeAcessarFaturamento()\"><a data-ui-sref=\"faturamento\" data-ng-click=\"sceiCtrl.sidebarStat($event)\"><i class=\"zmdi zmdi-money\"></i> Faturamento</a></li></ul></div><ul class=\"main-menu\"><li data-ui-sref-active=\"active\"><a data-ui-sref=\"home\" data-ng-click=\"sceiCtrl.sidebarStat($event)\"><i class=\"zmdi zmdi-home\"></i> Início</a></li><li data-ui-sref-active=\"active\" ng-show=\"sceiAdmin.usuarioPodeAcessarUsuarios()\"><a data-ui-sref=\"usuarios\" data-ng-click=\"sceiCtrl.sidebarStat($event)\"><i class=\"zmdi zmdi-male-alt\"></i> Usuários</a></li><li data-ui-sref-active=\"active\" ng-show=\"sceiAdmin.usuarioPodeAcessarGruposClientes()\"><a data-ui-sref=\"grupos\" data-ng-click=\"sceiCtrl.sidebarStat($event)\"><i class=\"zmdi zmdi-accounts\"></i> Grupos de clientes</a></li><li data-ui-sref-active=\"active\" ng-show=\"sceiAdmin.usuarioPodeAcessarClientes()\"><a data-ui-sref=\"clientes\" data-ng-click=\"sceiCtrl.sidebarStat($event)\"><i class=\"zmdi zmdi-account\"></i> Clientes</a></li><li data-ui-sref-active=\"active\" ng-show=\"sceiAdmin.usuarioPodeAcessarEquipamentos()\"><a data-ui-sref=\"equipamentos\" data-ng-click=\"sceiCtrl.sidebarStat($event)\"><i class=\"zmdi zmdi-fire\"></i> Equipamentos</a></li><li data-ui-sref-active=\"active\" ng-show=\"sceiAdmin.usuarioPodeAcessarManutencoes()\"><a data-ui-sref=\"manutencoes\" data-ng-click=\"sceiCtrl.sidebarStat($event)\"><i class=\"zmdi zmdi-edit\"></i> Manutenção</a></li></ul></div>"
  );

}]);
