﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using UnityEngine;
using UnityEditor;

namespace ArborEditor
{
	using Arbor;

	[CustomPropertyDrawer(typeof(ParameterConditionLegacy))]
	internal sealed class ParameterConditionLegacyPropertyDrawer : PropertyDrawer
	{
		private LayoutArea _LayoutArea = new LayoutArea();

		void DeleteOldBranch(ParameterConditionLegacyProperty conditionProperty, Parameter.Type type)
		{
			SerializedProperty valueProperty = null;
			switch (type)
			{
				case Parameter.Type.Int:
					{
						valueProperty = conditionProperty.intValueProperty;
					}
					break;
				case Parameter.Type.Long:
					{
						valueProperty = conditionProperty.longValueProperty;
					}
					break;
				case Parameter.Type.Float:
					{
						valueProperty = conditionProperty.floatValueProperty;
					}
					break;
				case Parameter.Type.Bool:
					{
						valueProperty = conditionProperty.boolValueProperty;
					}
					break;
				case Parameter.Type.String:
					{
						valueProperty = conditionProperty.stringValueProperty;
					}
					break;
				case Parameter.Type.GameObject:
					{
						valueProperty = conditionProperty.gameObjectValueProperty;
					}
					break;
				case Parameter.Type.Vector2:
					{
						valueProperty = conditionProperty.vector2ValueProperty;
					}
					break;
				case Parameter.Type.Vector3:
					{
						valueProperty = conditionProperty.vector3ValueProperty;
					}
					break;
				case Parameter.Type.Quaternion:
					{
						valueProperty = conditionProperty.quaternionValueProperty;
					}
					break;
				case Parameter.Type.Rect:
					{
						valueProperty = conditionProperty.rectValueProperty;
					}
					break;
				case Parameter.Type.Bounds:
					{
						valueProperty = conditionProperty.boundsValueProperty;
					}
					break;
				case Parameter.Type.Color:
					{
						valueProperty = conditionProperty.colorValueProperty;
					}
					break;
				case Parameter.Type.Transform:
					{
						valueProperty = conditionProperty.transformValueProperty;
					}
					break;
				case Parameter.Type.RectTransform:
					{
						valueProperty = conditionProperty.rectTransformValueProperty;
					}
					break;
				case Parameter.Type.Rigidbody:
					{
						valueProperty = conditionProperty.rigidbodyValueProperty;
					}
					break;
				case Parameter.Type.Rigidbody2D:
					{
						valueProperty = conditionProperty.rigidbody2DValueProperty;
					}
					break;
				case Parameter.Type.Component:
					{
						valueProperty = conditionProperty.componentValueProperty.property;
					}
					break;
				case Parameter.Type.AssetObject:
					{
						valueProperty = conditionProperty.assetObjectValueProperty.property;
					}
					break;
			}

			if (valueProperty != null)
			{
				switch (FlexibleUtility.GetPropertyType(type))
				{
					case FlexiblePropertyType.Primitive:
						{
							var flexibleProeprty = new FlexiblePrimitiveProperty(valueProperty);
							flexibleProeprty.Disconnect();
						}
						break;
					case FlexiblePropertyType.SceneObject:
						{
							var flexibleProperty = new FlexibleSceneObjectProperty(valueProperty);
							flexibleProperty.Disconnect();
						}
						break;
					case FlexiblePropertyType.Field:
						{
							var flexibleProperty = new FlexibleFieldProperty(valueProperty);
							flexibleProperty.Disconnect();
						}
						break;
				}
			}
		}

		void DoGUI(SerializedProperty property, GUIContent label)
		{
			ParameterConditionLegacyProperty conditionProperty = new ParameterConditionLegacyProperty(property);

			Parameter.Type oldParameterType = conditionProperty.GetParameterType();

			EditorGUI.BeginChangeCheck();
			_LayoutArea.PropertyField(conditionProperty.referenceProperty.property);
			if (EditorGUI.EndChangeCheck())
			{
				Parameter.Type parameterType = conditionProperty.GetParameterType();
				if (parameterType != oldParameterType)
				{
					DeleteOldBranch(conditionProperty, oldParameterType);

					property.serializedObject.ApplyModifiedProperties();

					GUIUtility.ExitGUI();
				}
			}

			ParameterReferenceType parameterReferenceType = conditionProperty.referenceProperty.type;
			if (parameterReferenceType == ParameterReferenceType.DataSlot)
			{
				EditorGUI.BeginChangeCheck();
				_LayoutArea.PropertyField(conditionProperty.parameterTypeProperty);
				if (EditorGUI.EndChangeCheck())
				{
					Parameter.Type parameterType = conditionProperty.GetParameterType();
					if (parameterType != oldParameterType)
					{
						DeleteOldBranch(conditionProperty, oldParameterType);

						conditionProperty.referenceType = null;

						property.serializedObject.ApplyModifiedProperties();

						GUIUtility.ExitGUI();
					}
				}

				if (ClassTypeConstraintEditorUtility.GetParameterTypeConstraint(oldParameterType, out var constraint))
				{
					System.Type oldReferenceType = conditionProperty.referenceType;

					if (constraint != null)
					{
						conditionProperty.referenceTypeProperty.SetConstraint(constraint);
					}

					EditorGUI.BeginChangeCheck();
					_LayoutArea.PropertyField(conditionProperty.referenceTypeProperty.property);
					if (EditorGUI.EndChangeCheck())
					{
						System.Type referenceType = conditionProperty.referenceType;
						if (referenceType != oldReferenceType)
						{
							DeleteOldBranch(conditionProperty, oldParameterType);

							property.serializedObject.ApplyModifiedProperties();

							GUIUtility.ExitGUI();
						}
					}
				}
			}

			if (parameterReferenceType == ParameterReferenceType.DataSlot || conditionProperty.referenceProperty.container != null)
			{
				ConditionGUI(conditionProperty);
			}
		}

		private void ConditionGUI(ParameterConditionLegacyProperty conditionProperty)
		{
			Parameter.Type parameterType = conditionProperty.GetParameterType();

			SerializedProperty compareTypeProperty = conditionProperty.compareTypeProperty;

			switch (parameterType)
			{
				case Parameter.Type.Int:
					{
						_LayoutArea.PropertyField(compareTypeProperty);
						_LayoutArea.PropertyField(conditionProperty.intValueProperty, EditorGUITools.GetTextContent("Int Value"));
					}
					break;
				case Parameter.Type.Long:
					{
						_LayoutArea.PropertyField(compareTypeProperty);
						_LayoutArea.PropertyField(conditionProperty.longValueProperty, EditorGUITools.GetTextContent("Long Value"));
					}
					break;
				case Parameter.Type.Float:
					{
						_LayoutArea.PropertyField(compareTypeProperty);
						_LayoutArea.PropertyField(conditionProperty.floatValueProperty, EditorGUITools.GetTextContent("Float Value"));
					}
					break;
				case Parameter.Type.Bool:
					{
						_LayoutArea.PropertyField(conditionProperty.boolValueProperty, EditorGUITools.GetTextContent("Bool Value"));
					}
					break;
				case Parameter.Type.String:
					{
						_LayoutArea.PropertyField(compareTypeProperty);
						_LayoutArea.PropertyField(conditionProperty.stringValueProperty, EditorGUITools.GetTextContent("String Value"));
					}
					break;
				case Parameter.Type.GameObject:
					{
						_LayoutArea.PropertyField(conditionProperty.gameObjectValueProperty, EditorGUITools.GetTextContent("GameObject Value"));
					}
					break;
				case Parameter.Type.Vector2:
					{
						_LayoutArea.PropertyField(conditionProperty.vector2ValueProperty, EditorGUITools.GetTextContent("Vector2 Value"));
					}
					break;
				case Parameter.Type.Vector3:
					{
						_LayoutArea.PropertyField(conditionProperty.vector3ValueProperty, EditorGUITools.GetTextContent("Vector3 Value"));
					}
					break;
				case Parameter.Type.Quaternion:
					{
						_LayoutArea.PropertyField(conditionProperty.quaternionValueProperty, EditorGUITools.GetTextContent("Quaternion Value"));
					}
					break;
				case Parameter.Type.Rect:
					{
						_LayoutArea.PropertyField(conditionProperty.rectValueProperty, EditorGUITools.GetTextContent("Rect Value"));
					}
					break;
				case Parameter.Type.Bounds:
					{
						_LayoutArea.PropertyField(conditionProperty.boundsValueProperty, EditorGUITools.GetTextContent("Bounds Value"));
					}
					break;
				case Parameter.Type.Color:
					{
						_LayoutArea.PropertyField(conditionProperty.colorValueProperty, EditorGUITools.GetTextContent("Color Value"));
					}
					break;
				case Parameter.Type.Transform:
					{
						_LayoutArea.PropertyField(conditionProperty.transformValueProperty, EditorGUITools.GetTextContent("Transform Value"));
					}
					break;
				case Parameter.Type.RectTransform:
					{
						_LayoutArea.PropertyField(conditionProperty.rectTransformValueProperty, EditorGUITools.GetTextContent("RectTransform Value"));
					}
					break;
				case Parameter.Type.Rigidbody:
					{
						_LayoutArea.PropertyField(conditionProperty.rigidbodyValueProperty, EditorGUITools.GetTextContent("Rigidbody Value"));
					}
					break;
				case Parameter.Type.Rigidbody2D:
					{
						_LayoutArea.PropertyField(conditionProperty.rigidbody2DValueProperty, EditorGUITools.GetTextContent("Rigidbody2D Value"));
					}
					break;
				case Parameter.Type.Component:
					{
						FlexibleComponentProperty componentValueProperty = conditionProperty.componentValueProperty;

						_LayoutArea.PropertyField(componentValueProperty.property, EditorGUITools.GetTextContent("Component Value"));
					}
					break;
				case Parameter.Type.Enum:
					{
						SerializedProperty enumValueProperty = conditionProperty.enumValueProperty;

						_LayoutArea.PropertyField(enumValueProperty, EditorGUITools.GetTextContent("Enum Value"));
					}
					break;
				case Parameter.Type.AssetObject:
					{
						FlexibleFieldProperty assetValueProperty = conditionProperty.assetObjectValueProperty;

						_LayoutArea.PropertyField(assetValueProperty.property, EditorGUITools.GetTextContent("AssetObject Value"));
					}
					break;
				case Parameter.Type.Variable:
					{
						Parameter parameter = conditionProperty.referenceProperty.GetParameter();
						string valueTypeName = (parameter != null && parameter.valueType != null) ? parameter.valueType.ToString() : "Variable";
						string message = string.Format(Localization.GetWord("ParameterCondition.NotSupportVariable"), valueTypeName);

						_LayoutArea.HelpBox(message, MessageType.Warning);
					}
					break;
				case Parameter.Type.VariableList:
					{
						Parameter parameter = conditionProperty.referenceProperty.GetParameter();
						string valueTypeName = (parameter != null && parameter.valueType != null) ? parameter.valueType.ToString() : "VariableList";
						string message = string.Format(Localization.GetWord("ParameterCondition.NotSupportVariableList"), valueTypeName);

						_LayoutArea.HelpBox(message, MessageType.Warning);
					}
					break;
			}
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			_LayoutArea.Begin(position, false, new RectOffset(0, 0, 2, 2));

			DoGUI(property, label);

			_LayoutArea.End();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			_LayoutArea.Begin(new Rect(), true, new RectOffset(0, 0, 2, 2));

			DoGUI(property, label);

			_LayoutArea.End();

			return _LayoutArea.rect.height;
		}
	}
}