CKEDITOR.dialog.add('moPlayer',　function(editor){
　　　　//定义参数
　　　　var moPlayerSwf=CKEDITOR.plugins.getPath("moplayer") + "CuPlayerMiniV4.swf",
　　　　    moPlayerImage=CKEDITOR.plugins.getPath("moplayer") + "images/start.jpg",
　　　　    moPlayerXml=CKEDITOR.plugins.getPath("moplayer") + "CuPlayerSetFile.xml"
　　　　;
　　　　var　escape　=　function(value){
　　　　　　　　return　value;
　　　　};
　　　　function UpdatePreview() {
		document.getElementById("_video_preview").innerHTML = ReturnPlayer()
	    }
	    function ReturnPlayer() {
	        var mysrc = CKEDITOR.dialog.getCurrent().getContentElement('info', 'src').getValue();
            var mywidth = CKEDITOR.dialog.getCurrent().getContentElement('info', 'mywidth').getValue();
            var myheight = CKEDITOR.dialog.getCurrent().getContentElement('info', 'myheight').getValue();
		    var JWEmbem = MoObject(mywidth,myheight,moPlayerXml,moPlayerSwf,moPlayerImage,mysrc);
		    return JWEmbem
	    }
　　　　return　{
　　　　　　　　title:　editor.lang.moplayer.title,
　　　　　　　　resizable:　CKEDITOR.DIALOG_RESIZE_BOTH,
　　　　　　　　minWidth: 420,
			    minHeight: 310,
　　　　　　　　contents:　[{
　　　　　　　　　　id: 'info',  
                    label: editor.lang.common.generalTab,
                    accessKey: 'I',
                    elements:[
                        {
                        type: 'hbox',
			            widths : [ '80%', '20%' ],
                        children:[{
                                id: 'src',
                                type: 'text',
                                label: editor.lang.common.url,
                                validate: CKEDITOR.dialog.validate.notEmpty(editor.lang.flash.validateSrc),
                                //选择文件后返回预览页面时加载
                                onChange :UpdatePreview
                            },{
                                type: 'button',
                                id: 'browse',
                                filebrowser: 'info:src',
                                hidden: true,
                                style:　'display:inline-block;margin-top:10px;text-align:center;width:85px;',
                                label: editor.lang.common.browseServer
                            }]
                        },
                        {
                        type: 'hbox',
			            widths : [ '35%', '35%', '30%' ],
                        children:[{
                            type:　'text',
　　　　　　　　　　　　　　label:　editor.lang.common.width,
　　　　　　　　　　　　　　id:　'mywidth',
　　　　　　　　　　　　　　'default':　'470',
　　　　　　　　　　　　　　style:　'width:100'
                        },{
                            type:　'text',
　　　　　　　　　　　　　　label:　editor.lang.common.height,
　　　　　　　　　　　　　　id:　'myheight',
　　　　　　　　　　　　　　'default':　'320',
　　　　　　　　　　　　　　style:　'width:100'
                        },{
                            type:　'select',
　　　　　　　　　　　　　　label:　editor.lang.moplayer.chkPlay,
　　　　　　　　　　　　　　id:　'myloop',
　　　　　　　　　　　　　　required:　true,
　　　　　　　　　　　　　　'default':　'false',
　　　　　　　　　　　　　　style:　'width:100',
　　　　　　　　　　　　　　items:　[[editor.lang.moplayer.yes,　'true'],　[editor.lang.moplayer.no,　'false']]
                        }]//children finish
                        },{
　　　　　　　　　　        type : 'html',
							id : 'preview',
							html : '<div id="_video_preview" class="FlashPreviewBox"></div>'
　　　　　　　　　　　　　　
　　　　　　　　　　    }]
                    }, {
                        id: 'Upload',
                        hidden: true,
                        filebrowser: 'uploadButton',
                        label: editor.lang.common.upload,
                        elements: [{
                            type: 'file',
                            id: 'upload',
                            label: editor.lang.common.upload,
                            size: 38
                        },
                        {
                            type: 'fileButton',
                            id: 'uploadButton',
                            label: editor.lang.common.uploadSubmit,
                            filebrowser: 'info:src',
                            'for': ['Upload', 'upload']
                        }]
　　　　　　　　}],
　　　　　　　　onOk:　function(){
　　　　　　　　　　　　mywidth　=　this.getValueOf('info',　'mywidth');
　　　　　　　　　　　　myheight　=　this.getValueOf('info',　'myheight');
　　　　　　　　　　　　myloop　=　this.getValueOf('info',　'myloop');
　　　　　　　　　　　　mysrc　=　this.getValueOf('info',　'src');
　　　　　　　　　　　　html　=　getRootPath()+''　+　escape(mysrc)　+　'';
　　　　　　　　　　　　//输出播放器
　　　　　　　　　　    editor.insertHtml(MoObject(mywidth,myheight,moPlayerXml,moPlayerSwf,moPlayerImage,html));
　　　　　　　　　　
　　　　　　　　},
　　　　　　　　onLoad:　function(){
　　　　　　　　}
　　　　　　　　
        };
        //取得根路径
        function getRootPath(){
            var strFullPath=window.document.location.href;
            var strPath=window.document.location.pathname;
            var pos=strFullPath.indexOf(strPath);
            var prePath=strFullPath.substring(0,pos);
            var postPath=strPath.substring(0,strPath.substr(1).indexOf('/')+1);
            return(prePath);
        }
        //播放器控制代码
        function MoObject(width,height,xml,swf,image,file)
        {
            return "<object align=\"middle\" classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0\" height=\""　+　height　+　"\" id=\"simplevideostreaming\" width=\""　+　width　+　"\"><param name=\"allowScriptAccess\" value=\"sameDomain\" /><param name=\"allowFullScreen\" value=\"true\" /><param name=\"movie\" value=\"" + swf + "\" /><param name=\"FlashVars\" value=\"&amp;CuPlayerSetFile=" + xml + "&amp;CuPlayerFile="　+　file　+　"&amp;CuPlayerImage=" + image + "&amp;CuPlayerWidth="　+　width　+　"&amp;CuPlayerHeight="　+　height　+　"&amp;CuPlayerAutoPlay=false&amp;CuPlayerAutoRepeat=true&amp;CuPlayerShowControl=false&amp;CuPlayerAutoHideControl=false&amp;CuPlayerAutoHideTime=5&amp;CuPlayerVolume=80&amp;CuPlayerGetNext=false\" /><param name=\"quality\" value=\"high\" /><param name=\"bgcolor\" value=\"#000000\" /><embed align=\"middle\" allowfullscreen=\"true\" allowscriptaccess=\"sameDomain\" bgcolor=\"#000000\" flashvars=\"&amp;CuPlayerSetFile=" + xml + "&amp;CuPlayerFile="　+　file　+　"&amp;CuPlayerImage=" + image + "&amp;CuPlayerWidth="　+　width　+　"&amp;CuPlayerHeight="　+　height　+　"&amp;CuPlayerAutoPlay=false&amp;CuPlayerAutoRepeat=true&amp;CuPlayerShowControl=false&amp;CuPlayerAutoHideControl=false&amp;CuPlayerAutoHideTime=5&amp;CuPlayerVolume=80&amp;CuPlayerGetNext=false\" height=\""　+　height　+　"\" name=\"simplevideostreaming\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" quality=\"high\" src=\"" + swf + "\" type=\"application/x-shockwave-flash\" width=\""　+　width　+　"\"></embed></object>";
        }

});
