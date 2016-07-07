//alert(navigator.userAgent)
 function resizeLayout()
   {
      var wWidth = (window.document.documentElement.clientWidth || window.document.body.clientWidth || window.innerWidth);
      var wHeight = (window.document.documentElement.clientHeight || window.document.body.clientHeight || window.innerHeight);
      var nHeight = $('#north').outerHeight();
      var fHeight = $('#funcbar').outerHeight();
      var cHeight = wHeight - nHeight - fHeight - $('#south').outerHeight() - $('#taskbar').outerHeight();
      $('#center').height(cHeight);
	  $('.slide_menulist').height(cHeight-$('.slide_nav').outerHeight());
      $("#center iframe").css({height: cHeight});
    }
 $(window).resize(function(){resizeLayout();slideMenu();});
 
 
 $(document).ready(function(){
	 resizeLayout(); //调整窗口大小
	 slideMenu(); //主菜单
	 
	 menuTab(); //点击窗口
	 message(); //消息
	 mail_box();//点击消息
	 start_menu();//开始菜单
	 mainmenu();
	 })
	 
	function slideMenu(){
			var wWidth = (window.document.documentElement.clientWidth || window.document.body.clientWidth || window.innerWidth);
			$(".slide_box ul").each(function(){
				$(this).css("width",wWidth-160+"px");
			})
			$(".slide_box").css("width",($(".slide_box ul").length*wWidth)+"px");
			$(".slide_nav a").click(function(){
					$(".slide_nav a").removeClass("chosen");
					$(".slide_box").stop().animate({left:"-"+$(this).index()*wWidth+"px"},500)
					$(".slide_nav a").eq($(this).index()).addClass("chosen");
				})
		}
	
	function menuTab(){
			var HasIframe=false;
			//$("body").className="";
			var FrameNum=0;
			$(".slide_box li,.menu_right li").click(function(){
				$(".top_menu").stop().slideUp("fast");
				$("#overlay_startmenu").hide();
				var _this=$(this);
				
				$("body").removeClass().addClass(_this.attr("color"));
				$("#center iframe").each(function(){
							if($(this).attr("src")==_this.find("a").attr("rel")){
								$("#center iframe").removeClass("selected");
							    $(".mainnav").removeClass("selected");
							    $("#tabs_container div").removeClass("selected");
								$(this).addClass("selected");
							
								$("#tabs_portal_"+$(this).attr("id").substr(1)).addClass("selected");
								HasIframe=true;
								}
					})
					if(HasIframe){HasIframe=false;return}
					var newIframe="<iframe scrolling='auto' frameborder='0' style='background:#fff;' class='selected' height='100%' width='100%' id='t"+parseInt(FrameNum+1)+"' src='"+_this.find("a").attr("rel")+"'></iframe>";			
					var newButton="<div id='tabs_portal_"+parseInt(FrameNum+1)+"' class='selected'><a color="+_this.attr("color")+"  href='javascript:;' class='tab'>"+_this.find("a").attr("title")+"</a><a href='javascript:;' class='close'></a></div>";
					
					$(".mainnav iframe").removeClass("selected");
					$(".mainnav").removeClass("selected");
					$("#tabs_container div").removeClass("selected");
					$("#center").append(newIframe);
					$("#tabs_container").append(newButton);
					FrameNum++;
					$("#tabs_container a[class=tab]").bind("click",function(){
				    var _Inum=$(this).parent().attr("id").substr(12);
					$("body").removeClass().addClass($(this).attr("color"));
					$("#center iframe").removeClass("selected");
					$(".mainnav").removeClass("selected");
					$("#tabs_container div").removeClass("selected");
					if(_Inum==0){
								$("#tabs_portal_"+_Inum).addClass("selected");
								$(".mainnav").addClass("selected");
								return;
							}
						else{	
								  $("#t"+_Inum).addClass("selected");
									$("#tabs_portal_"+_Inum).addClass("selected");	
							}
					})
					closeTab();//关闭窗口
				})
		}
	
	
	
	function closeTab(){
			$("#tabs_container a[class=close]").bind("click",function(){
			var Inum=$(this).parent().attr("id").substr(12);
			$(this).parent().attr("id","t99");
			$(this).parent().remove();
			$("#t"+Inum).remove();
			$("body").removeClass().addClass("blue");
			$("#tabs_portal_0").addClass("selected");
			$(".mainnav").addClass("selected");
		})
	}
	
	function message(){
			$(".mail_box").css({"bottom":"-"+$(".mail_box").height()+"px"})
			$("#mail").click(function(){
					$(".mail_box").show().stop().animate({"bottom":"30px"})
				})
			$(".mail_close a").click(function(){
					$(".mail_box").stop().animate({"bottom":"-"+$(".mail_box").height()+"px"},function(){$(".mail_box").hide();})
				})
		}
	
	function mail_box(){
			$(".mail_box ul a").click(function(){
					$(".mail_c").show().find("span").text($(this).find("b").text()).end().find("iframe").attr("src",$(this).attr("rel"));
				})
			$(".mail_c_close").click(function(){
					$(".mail_c").hide();
				})
		}
		
	function start_btn(){
			$(".start_menu").click(function(){
					
				})
		}
	function start_menu(){
		$("#start_menu").click(function(){
				$(".top_menu").stop().slideDown("fast");
				$("#overlay_startmenu").show();
			})
		$("#overlay_startmenu").click(function(){
				$(".top_menu").stop().slideUp("fast");
				$("#overlay_startmenu").hide();
			})
		}
	
	function mainmenu(){
			$(".menu_left li").click(function(){
					$(".menu_right>ul").eq($(this).index()).show().siblings("ul").hide();
				})
		}