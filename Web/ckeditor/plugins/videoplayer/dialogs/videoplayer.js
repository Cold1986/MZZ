/**
 * @license Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

(function() {
	// It is possible to set things in three different places.
	// 1. As attributes in the object tag.
	// 2. As param tags under the object tag.
	// 3. As attributes in the embed tag.
	// It is possible for a single attribute to be present in more than one place.
	// So let's define a mapping between a sementic attribute and its syntactic
	// equivalents.
	// Then we'll set and retrieve attribute values according to the mapping,
	// instead of having to check and set each syntactic attribute every time.
	//
	// Reference: http://kb.adobe.com/selfservice/viewContent.do?externalId=tn_12701
	var ATTRTYPE_OBJECT = 1,
		ATTRTYPE_PARAM = 2,
		ATTRTYPE_EMBED = 4;

	var attributesMap = {
		id: [ {
			type: ATTRTYPE_OBJECT, name: 'id'
		}],
		classid: [ {
			type: ATTRTYPE_OBJECT, name: 'classid'
		}],
		codebase: [ {
			type: ATTRTYPE_OBJECT, name: 'codebase'
		}],
		pluginspage: [ {
			type: ATTRTYPE_EMBED, name: 'pluginspage'
		}],
		src: [ {
		    type: ATTRTYPE_PARAM, name: 'url'
		}, {
			type: ATTRTYPE_EMBED, name: 'src'
		}, {
			type: ATTRTYPE_OBJECT, name: 'data'
		}],
		name: [ {
			type: ATTRTYPE_EMBED, name: 'name'
		}],
		align: [ {
			type: ATTRTYPE_OBJECT, name: 'align'
		}],
		'class': [ {
			type: ATTRTYPE_OBJECT, name: 'class'
		}, {
			type: ATTRTYPE_EMBED, name: 'class'
		}],
		width: [ {
			type: ATTRTYPE_OBJECT, name: 'width'
		}, {
			type: ATTRTYPE_EMBED, name: 'width'
		}],
		height: [ {
			type: ATTRTYPE_OBJECT, name: 'height'
		}, {
			type: ATTRTYPE_EMBED, name: 'height'
		}],
		style: [ {
			type: ATTRTYPE_OBJECT, name: 'style'
		}, {
			type: ATTRTYPE_EMBED, name: 'style'
		}],
		type: [{
		    type: ATTRTYPE_OBJECT, name: 'type'
		}, {
			type: ATTRTYPE_EMBED, name: 'type'
		}]
	};

	var names = ['AutoStart', 'EnableContextMenu', 'uiMode', 'windowlessVideo', 'fullScreen', 'wmode', 'bgcolor', 'base', 'flashvars'];
	for ( var i = 0; i < names.length; i++ )
		attributesMap[ names[ i ] ] = [ {
		type: ATTRTYPE_EMBED, name: names[ i ]
	}, {
		type: ATTRTYPE_PARAM, name: names[ i ]
	}];

	var otherAttributesMap = new Array(
        [{ name: 'Balance', value: '0' }],
        [{ name: 'enabled', value: '-1' }],
        [{ name: 'PlayCount', value: '1' }],
        [{ name: 'rate', value: '1' }],
        [{ name: 'currentPosition', value: '0' }],
        [{ name: 'currentMarker', value: '0' }], 
        [{ name: 'defaultFrame', value: '' }], 
        [{ name: 'defaultFrame', value: '' }],
        [{ name: 'baseURL', value: '' }],
        [{ name: 'stretchToFit', value: '0' }],
        [{ name: 'volume', value: '50' }],
        [{ name: 'mute', value: '0' }],
        [{ name: 'enableErrorDialogs', value: '-1' }],
        [{ name: 'SAMIStyle', value: '' }],
        [{ name: 'SAMILang', value: '' }],
        [{ name: 'SAMIFilename', value: '' }]);

	/*names = ['AutoStart', 'EnableContextMenu', 'fullScreen'];
	for ( i = 0; i < names.length; i++ )
		attributesMap[ names[ i ] ][ 0 ][ 'default' ] = attributesMap[ names[ i ] ][ 1 ][ 'default' ] = true;*/

	var defaultToPixel = CKEDITOR.tools.cssLength;

	function loadValue( objectNode, embedNode, paramMap ) {
		var attributes = attributesMap[ this.id ];
		if ( !attributes )
			return;

		var isCheckbox = ( this instanceof CKEDITOR.ui.dialog.checkbox );
		for ( var i = 0; i < attributes.length; i++ ) {
			var attrDef = attributes[ i ];
			switch ( attrDef.type ) {
				case ATTRTYPE_OBJECT:
					if ( !objectNode )
						continue;
					if ( objectNode.getAttribute( attrDef.name ) !== null ) {
						var value = objectNode.getAttribute( attrDef.name );
						if ( isCheckbox )
							this.setValue( value.toLowerCase() == 'true' );
						else
							this.setValue( value );
						return;
					} else if ( isCheckbox )
						this.setValue( !!attrDef[ 'default' ] );
					break;
				case ATTRTYPE_PARAM:
					if ( !objectNode )
						continue;
					if ( attrDef.name in paramMap ) {
						value = paramMap[ attrDef.name ];
						if ( isCheckbox )
							this.setValue( value.toLowerCase() == 'true' );
						else
							this.setValue( value );
						return;
					} else if ( isCheckbox )
						this.setValue( !!attrDef[ 'default' ] );
					break;
				case ATTRTYPE_EMBED:
					if ( !embedNode )
						continue;
					if ( embedNode.getAttribute( attrDef.name ) ) {
						value = embedNode.getAttribute( attrDef.name );
						if ( isCheckbox )
							this.setValue( value.toLowerCase() == 'true' );
						else
							this.setValue( value );
						return;
					} else if ( isCheckbox )
						this.setValue( !!attrDef[ 'default' ] );
			}
		}
	}

	function commitValue( objectNode, embedNode, paramMap ) {
		var attributes = attributesMap[ this.id ];
		if ( !attributes )
		    return;
		var isRemove = ( this.getValue() === '' ),
			isCheckbox = ( this instanceof CKEDITOR.ui.dialog.checkbox );

		for ( var i = 0; i < attributes.length; i++ ) {
			var attrDef = attributes[ i ];
			switch ( attrDef.type ) {
				case ATTRTYPE_OBJECT:
					// Avoid applying the data attribute when not needed (#7733)
					if ( !objectNode || ( attrDef.name == 'data' && embedNode && !objectNode.hasAttribute( 'data' ) ) )
						continue;
					var value = this.getValue();
					if ( isRemove || isCheckbox && value === attrDef[ 'default' ] )
						objectNode.removeAttribute( attrDef.name );
					else
						objectNode.setAttribute( attrDef.name, value );
					break;
				case ATTRTYPE_PARAM:
					if ( !objectNode )
						continue;
					value = this.getValue();
					if ( isRemove || isCheckbox && value === attrDef[ 'default' ] ) {
						if ( attrDef.name in paramMap )
							paramMap[ attrDef.name ].remove();
					} else {
						if ( attrDef.name in paramMap )
							paramMap[ attrDef.name ].setAttribute( 'value', value );
						else {
							var param = CKEDITOR.dom.element.createFromHtml( '<cke:param></cke:param>', objectNode.getDocument() );
							param.setAttributes({ name: attrDef.name, value: value } );
							if ( objectNode.getChildCount() < 1 )
								param.appendTo( objectNode );
							else
								param.insertBefore( objectNode.getFirst() );
						}
					}
					break;
				case ATTRTYPE_EMBED:
					if ( !embedNode )
						continue;
					value = this.getValue();
					if ( isRemove || isCheckbox && value === attrDef[ 'default' ] )
						embedNode.removeAttribute( attrDef.name );
					else
						embedNode.setAttribute( attrDef.name, value );
			}
		}
	}

	CKEDITOR.dialog.add( 'videoplayer', function( editor ) {
		var makeObjectTag = !editor.config.videoEmbedTagOnly,
			makeEmbedTag = editor.config.videoAddEmbedTag || editor.config.videoEmbedTagOnly;

		var previewPreloader,
			previewAreaHtml = '<div>' + CKEDITOR.tools.htmlEncode( editor.lang.common.preview ) + '<br>' +
			'<div id="cke_VideoPreviewLoader' + CKEDITOR.tools.getNextNumber() + '" style="display:none"><div class="loading">&nbsp;</div></div>' +
			'<div id="cke_VideoPreviewBox' + CKEDITOR.tools.getNextNumber() + '" class="VideoPreviewBox"></div></div>';

		return {
			title: editor.lang.videoplayer.title,
			minWidth: 420,
			minHeight: 310,
			onShow: function() {
				// Clear previously saved elements.
				this.fakeImage = this.objectNode = this.embedNode = null;
				previewPreloader = new CKEDITOR.dom.element( 'embed', editor.document );

				// Try to detect any embed or object tag that has Flash parameters.
				var fakeImage = this.getSelectedElement();
				if (fakeImage && fakeImage.data('cke-real-element-type') && fakeImage.data('cke-real-element-type') == 'videoplayer') {
				    this.fakeImage = fakeImage;

				    var realElement = editor.restoreRealElement(fakeImage),
						objectNode = null,
						embedNode = null,
						paramMap = {};

				    if (realElement.getName() == 'cke:object') {
				        objectNode = realElement;
				        var embedList = objectNode.getElementsByTag('embed', 'cke');
				        if (embedList.count() > 0)
				            embedNode = embedList.getItem(0);
				        var paramList = objectNode.getElementsByTag('param', 'cke');
				        for (var i = 0, length = paramList.count() ; i < length; i++) {
				            var item = paramList.getItem(i),
                                name = item.getAttribute('name'),
                                value = item.getAttribute('value');
				            paramMap[name] = value;
				        }
				    } else if (realElement.getName() == 'cke:embed')
				        embedNode = realElement;

				    this.objectNode = objectNode;
				    this.embedNode = embedNode;

				    this.setupContent(objectNode, embedNode, paramMap, fakeImage);
				}
			},
			onOk: function() {
				// If there's no selected object or embed, create one. Otherwise, reuse the
				// selected object and embed nodes.
				var objectNode = null,
					embedNode = null,
					paramMap = null;
				if ( !this.fakeImage ) {
					if ( makeObjectTag ) {
						objectNode = CKEDITOR.dom.element.createFromHtml( '<cke:object></cke:object>', editor.document );
						var attributes = {
						    classid: 'clsid:6bf52a52-394a-11d3-b153-00c04f79faa6',
						    type: 'application/x-oleobject',
						    codebase: 'http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,4,5,715'
						};
						objectNode.setAttributes( attributes );
					}
					if ( makeEmbedTag ) {
						embedNode = CKEDITOR.dom.element.createFromHtml( '<cke:embed></cke:embed>', editor.document );
						embedNode.setAttributes({
						    type: 'application/x-mplayer2',
						    border:'0',
						    pluginspage: 'http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,4,5,715'
						});
						var otherName = null;
						for (var i = 0; i < otherAttributesMap.length; i++) {
						    otherName = otherAttributesMap[i][0];
						    embedNode.setAttribute(otherName.name, otherName.value);
						}
						if (objectNode)
						    embedNode.appendTo(objectNode);
						
					}
				} else {
					objectNode = this.objectNode;
					embedNode = this.embedNode;
				}

				// Produce the paramMap if there's an object tag.
				if (objectNode) {
				    			    
				    for (var i = 0; i < otherAttributesMap.length; i++) {
				        var param = CKEDITOR.dom.element.createFromHtml('<cke:param></cke:param>', objectNode.getDocument());
				        param.setAttributes({ name: otherAttributesMap[i][0].name, value: otherAttributesMap[i][0].value });
				        if (objectNode.getChildCount() < 1)
				            param.appendTo(objectNode);
				        else
				            param.insertBefore(objectNode.getFirst());
				    }

				    paramMap = {};
				    var paramList = objectNode.getElementsByTag('param', 'cke');
				    for (var i = 0, length = paramList.count() ; i < length; i++)
				        paramMap[paramList.getItem(i).getAttribute('name')] = paramList.getItem(i);
				}

				// A subset of the specified attributes/styles
				// should also be applied on the fake element to
				// have better visual effect. (#5240)
				var extraStyles = {},
					extraAttributes = {};
				this.commitContent( objectNode, embedNode, paramMap, extraStyles, extraAttributes );

				// Refresh the fake image.
				var newFakeImage = editor.createFakeElement( objectNode || embedNode, 'cke_videoplayer', 'videoplayer', true );
				newFakeImage.setAttributes( extraAttributes );
				newFakeImage.setStyles( extraStyles );
				if ( this.fakeImage ) {
					newFakeImage.replace( this.fakeImage );
					editor.getSelection().selectElement( newFakeImage );
				} else
					editor.insertElement( newFakeImage );
			},

			onHide: function() {
				if ( this.preview )
					this.preview.setHtml( '' );
			},

			contents: [
				{
				id: 'info',
				label: editor.lang.videoplayer.info,
				accessKey: 'I',
				elements: [
					{
					type: 'vbox',
					padding: 0,
					children: [
						{
						type: 'hbox',
						widths: [ '280px', '110px' ],
						align: 'right',
						children: [
							{
							id: 'src',
							type: 'text',
							label: editor.lang.common.url,
							required: true,
							validate: CKEDITOR.dialog.validate.notEmpty(editor.lang.videoplayer.validateSrc),
							setup: loadValue,
							commit: commitValue,
							onLoad: function() {
								var dialog = this.getDialog(),
									updatePreview = function( src ) {
										// Query the preloader to figure out the url impacted by based href.
										previewPreloader.setAttribute( 'src', src );
										dialog.preview.setHtml( '<embed height="100%" width="100%" src="' + CKEDITOR.tools.htmlEncode( previewPreloader.getAttribute( 'src' ) )
											+ '" type="application/x-mplayer2"></embed>');
									};
								// Preview element
								dialog.preview = dialog.getContentElement( 'info', 'preview' ).getElement().getChild( 3 );

								// Sync on inital value loaded.
								this.on( 'change', function( evt ) {

									if ( evt.data && evt.data.value )
										updatePreview( evt.data.value );
								});
								// Sync when input value changed.
								this.getInputElement().on( 'change', function( evt ) {

									updatePreview( this.getValue() );
								}, this );
							}
						},
							{
							type: 'button',
							id: 'browse',
							filebrowser: 'info:src',
							hidden: true,
							// v-align with the 'src' field.
							// TODO: We need something better than a fixed size here.
							style: 'display:inline-block;margin-top:10px;',
							label: editor.lang.common.browseServer
						}
						]
					}
					]
				},
					{
					    type: 'hbox',
					    widths: ['25%', '25%', '25%', '25%', '25%'],
					    children: [
                            {
                                type: 'text',
                                id: 'id',
                                'default': 'videoplayer',
                                label: editor.lang.common.id,
                                style: 'width:190px',
                                setup: loadValue,
                                commit: commitValue
                            },
                            {
                                type: 'text',
                                id: 'width',
                                'default': '320px',
                                style: 'width:95px',
                                label: editor.lang.common.width,
                                validate: CKEDITOR.dialog.validate.htmlLength(editor.lang.common.invalidHtmlLength.replace('%1', editor.lang.common.width)),
                                setup: loadValue,
                                commit: commitValue
                            },
                            {
                                type: 'text',
                                id: 'height',
                                'default': '240px',
                                style: 'width:95px',
                                label: editor.lang.common.height,
                                validate: CKEDITOR.dialog.validate.htmlLength(editor.lang.common.invalidHtmlLength.replace('%1', editor.lang.common.height)),
                                setup: loadValue,
                                commit: commitValue
                            }
					    ]
					},

					{
					type: 'vbox',
					children: [
						{
						type: 'html',
						id: 'preview',
						style: 'width:95%;',
						html: previewAreaHtml
					}
					]
				}
				]
			},
				{
				id: 'Upload',
				hidden: true,
				filebrowser: 'uploadButton',
				label: editor.lang.common.upload,
				elements: [
					{
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
					'for': [ 'Upload', 'upload' ]
				}
				]
			},
				{
				id: 'properties',
				label: editor.lang.videoplayer.propertiesTab,
				elements: [
					{
					    type: 'hbox',
					    widths: ['50%', '50%'],
					    children: [
                            {
                                id: 'wmode',
                                type: 'select',
                                label: editor.lang.videoplayer.windowMode,
                                'default': '',
                                style: 'width : 100%;',
                                items: [
                                    [editor.lang.common.notSet, ''],
                                    [editor.lang.videoplayer.windowModeWindow, 'window'],
                                    [editor.lang.videoplayer.windowModeOpaque, 'opaque'],
                                    [editor.lang.videoplayer.windowModeTransparent, 'transparent']
                                ],
                                setup: loadValue,
                                commit: commitValue
                            },
                            {
                                type: 'select',
                                id: 'uiMode',
                                label: editor.lang.videoplayer.chkuiMode,
                                items: [[editor.lang.videoplayer.chkuiModefull, 'full'],
                                        [editor.lang.videoplayer.chkuiModemini, 'mini'],
                                        [editor.lang.videoplayer.chkuiModenone, 'none'],
                                        [editor.lang.videoplayer.chkuiModeinvisible, 'invisible']],
                                'default': 'full',
                                style: 'width : 100%;',
                                setup: loadValue,
                                commit: commitValue
                            }
					    ]
					},
					{
					    type: 'hbox',
					    widths: ['50%', '50%'],
					    children: [
                            {
                                type: 'html',
                                html: '<div></div>'
                            }
					    ]
					},
					{
					type: 'fieldset',
					label: CKEDITOR.tools.htmlEncode(editor.lang.videoplayer.flashvars),
					children: [
						{
						    type: 'hbox',
						    widths: ['25%', '25%', '25%', '25%'],
						    children: [
                               {
                                type: 'select',
                                id: 'AutoStart',
                                label: editor.lang.videoplayer.chkAutoStart,
                                'default': '1',
                                style: 'width : 100%;',
                                items: [[editor.lang.videoplayer.yes, '1'], [editor.lang.videoplayer.no, '0']],
                                setup: loadValue,
                                commit: commitValue
                            },
                                {
                                    type: 'select',
                                    id: 'EnableContextMenu',
                                    label: editor.lang.videoplayer.chkEnableContextMenu,
                                    items: [[editor.lang.videoplayer.yes, '1'], [editor.lang.videoplayer.no, '0']],
                                    'default': '1',
                                    style: 'width : 100%;',
                                    setup: loadValue,
                                    commit: commitValue
                                },
                                {
                                    type: 'select',
                                    id: 'fullScreen',
                                    label: editor.lang.videoplayer.chkfullScreen,
                                    items: [[editor.lang.videoplayer.yes, '1'], [editor.lang.videoplayer.no, '0']],
                                    'default': '0',
                                    style: 'width : 100%;',
                                    setup: loadValue,
                                    commit: commitValue
                                },
                                {
                                    type: 'select',
                                    id: 'windowlessVideo',
                                    label: editor.lang.videoplayer.chkwindowlessVideo,
                                    items: [[editor.lang.videoplayer.yes, '1'], [editor.lang.videoplayer.no, '0']],
                                    'default': '1',
                                    style: 'width : 100%;',
                                    setup: loadValue,
                                    commit: commitValue
                                }
						    ]
						}
					]
					},
                    {
                        type: 'hbox',
                        widths: ['50%', '50%'],
                        children: [
                            {
                                type: 'html',
                                html: '<div></div>'
                            }
                        ]
                    },
                    {
                        type: 'hbox',
                        widths: ['45%', '55%'],
                        children: [
                            {
                                type: 'text',
                                id: 'bgcolor',
                                label: editor.lang.videoplayer.bgcolor,
                                setup: loadValue,
                                commit: commitValue
                            },
                            {
                                type: 'text',
                                id: 'class',
                                label: editor.lang.common.cssClass,
                                setup: loadValue,
                                commit: commitValue
                            }
                        ]
                    },
                    {
                        type: 'text',
                        id: 'style',
                        validate: CKEDITOR.dialog.validate.inlineStyle(editor.lang.common.invalidInlineStyle),
                        label: editor.lang.common.cssStyle,
                        setup: loadValue,
                        commit: commitValue
                    }

				]
			}
			]
		};
	});
})();
/* <object id="player" width='320' height='240' classid="CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6">';
            <param name="AutoStart" value='1' />;//<!--自动播放--> 
            <param name="Balance" value="0" />;//<!--调整左右声道平衡-->     
            <param name="enabled" value="-1" />//<!--播放器是否可人为控制--> 
            <param name="EnableContextMenu" value="-1" />//<!--是否启用上下文菜单--> 
            <param name="url" value='+ url +' />;//<!--播放的文件地址-->   
            <param name="PlayCount" value="1" />;//<!--播放次数控制,为整数--> 
            <param name="rate" value="1" />;//<!--播放速率控制,1为正常,允许小数,1.0-2.0-->  
            <param name="currentPosition" value="0" />;//<!--控件设置:当前位置--> 
            <param name="currentMarker" value="0" />;//<!--控件设置:当前标记--> 
            <param name="defaultFrame" value="" />;//<!--显示默认框架--> 
            <param name="invokeURLs" value="0" />;//<!--脚本命令设置:是否调用URL--> 
            <param name="baseURL" value="" />;//<!--脚本命令设置:被调用的URL--> 
            <param name="stretchToFit" value="0" />;//<!--是否按比例伸展--> 
            <param name="volume" value="50" />;//<!--默认声音大小0%-100%,50则为50%--> 
            <param name="mute" value="0" />; //<!--是否静音--> 
            <param name="uiMode" value="full" />;//<!--播放器显示模式:Full显示全部;mini最简化;None不显示播放控制,只显示视频窗口;invisible全部不显示--> 
            <param name="windowlessVideo" value="1" />;//<!--如果是0可以允许全屏,否则只能在窗口中查看--> 
            <param name="fullScreen" value="0" />;//<!--开始播放是否自动全屏--> 
            <param name="enableErrorDialogs" value="-1" />;//<!--是否启用错误提示报告--> 
            <param name="SAMIStyle" value="" />;//<!--SAMI样式--> 
            <param name="SAMILang" value="" />;//<!--SAMI语言--> 
            <param name="SAMIFilename" value="" />;//<!--字幕ID--> 
            <embed border="0"  width='320' height='240' src='+ url +' id="emPlayer" type="application/x-mplayer2"></embed></object>;//<!--字幕ID--> */